using MediatR;
using Microsoft.Extensions.Configuration;
using Wellness.Application.Interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Wellness.Application.DTOs.Commands
{
    public class RefreshTokenCommandHandler(IUserRepository userRepository, IJwtService jwtService,
        IConfiguration configuration) : IRequestHandler<RefreshTokenCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJwtService _jwtService = jwtService;
        private readonly IConfiguration _configuration = configuration;

        public async Task<LoginResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = GetPrincipalFromExpiredToken(request.Token);
            if (principal == null)
                throw new Exception("Invalid access token or refresh token");

            var userIdString = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdString, out var userId))
                throw new Exception("Invalid token claims");

            var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
            if (user == null || !user.IsActive)
                throw new Exception("Invalid token claims or inactive user");

            var existingRefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.Token == request.RefreshToken);
            
            if (existingRefreshToken == null || existingRefreshToken.ExpiryDate <= DateTime.UtcNow || existingRefreshToken.IsRevoked)
                throw new Exception("Invalid refresh token");

            // Revoke the old refresh token
            existingRefreshToken.IsRevoked = true;

            // Generate new tokens
            var newJwtToken = _jwtService.GenerateToken(user);
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            user.RefreshTokens.Add(new Domain.Entities.RefreshToken
            {
                Token = newRefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                UserId = user.Id
            });

            await _userRepository.SaveChangesAsync(cancellationToken);

            return new LoginResponseDto
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken,
                FullName = $"{user.FirstName} {user.LastName}",
                Expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"]))
            };
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
                ValidateLifetime = false // Here we are saying that we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            
            if (securityToken is not JwtSecurityToken jwtSecurityToken || 
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
