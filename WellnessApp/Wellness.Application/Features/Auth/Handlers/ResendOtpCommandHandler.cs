using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.DTOs.Commands;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Auth.Handlers
{
    public class ResendOtpCommandHandler(
        IUserRepository userRepository,
        IEmailService emailService) : IRequestHandler<ResendOtpCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IEmailService _emailService = emailService;

        public async Task<bool> Handle(
            ResendOtpCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetByEmailAsync(request.Email, cancellationToken) ?? throw new Exception("User not found");
            var otp = new Random().Next(100000, 999999).ToString();

            user.EmailVerificationToken = otp;

            await _userRepository.UpdateUserAsync(user, user.Id, cancellationToken);

            await _emailService.SendEmailAsync(
                user.Email,
                "OTP Verification",
                $"Your OTP is: {otp}");

            return true;
        }
    }
}
