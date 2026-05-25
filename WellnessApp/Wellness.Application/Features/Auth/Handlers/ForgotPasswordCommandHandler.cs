using MediatR;
using Wellness.Application.DTOs.Commands;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Auth.Commands
{
    public class ForgotPasswordCommandHandler(IUserRepository userRepository, IEmailService emailService) : IRequestHandler<ForgotPasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IEmailService _emailService = emailService;

        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken) ?? throw new Exception("User not found");
            var token = Guid.NewGuid().ToString();

            user.ResetToken = token;
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1);

            await _userRepository.UpdateUserAsync(user, user.Id, cancellationToken);
            
            var resetLink = $"https://yourdomain.com/reset-password?token={token}&email={user.Email}";
            var body = $@"
            <h2>Password Reset</h2>
            <p>Hello {user.FirstName},</p>
            <p>Please click below link to reset your password.</p>
            <a href='{resetLink}'>Reset Password</a>
            <p>This link expires in 1 hour.</p>";

            await _emailService.SendEmailAsync(
             user.Email,
             "Reset Password",
             body);

            return true;
        }
    }
}
