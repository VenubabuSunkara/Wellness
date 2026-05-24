using MediatR;
using Microsoft.Extensions.Configuration;
using Wellness.Application.DTOs;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Auth.Commands
{
    public class LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService,
        IConfiguration configuration) : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJwtService _jwtService = jwtService;
        private readonly IConfiguration _configuration = configuration;
        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

            if (user == null)
            {
                throw new Exception("Invalid User");
            }
            // Save password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Verify password
            bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!isValid)
            {
                throw new Exception("Invalid Password");
            }

            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                FullName = $"{user.FirstName} {user.LastName}",
                Expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"]))
            };
        }
    }
}
