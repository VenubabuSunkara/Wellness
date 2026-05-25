using MediatR;
using Microsoft.Extensions.Configuration;
using Wellness.Application.DTOs;
using Wellness.Application.Interfaces;

namespace Wellness.Application.DTOs.Commands
{
    public class LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService,
        IConfiguration configuration) : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJwtService _jwtService = jwtService;
        private readonly IConfiguration _configuration = configuration;
        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken) ?? throw new Exception("Invalid User");
            // Verify password
            bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!isValid)
            {
                throw new Exception("Invalid Password");
            }

            var token = _jwtService.GenerateToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();
            
            user.RefreshTokens.Add(new Domain.Entities.RefreshToken
            {
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7), // Hardcoded 7 days for now, can be moved to config
                UserId = user.Id
            });

            await _userRepository.SaveChangesAsync(cancellationToken);

            return new LoginResponseDto
            {
                Token = token,
                RefreshToken = refreshToken,
                FullName = $"{user.FirstName} {user.LastName}",
                Expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"]))
            };
        }
    }
}
