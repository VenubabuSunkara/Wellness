using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.DTOs.Commands;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Auth.Handlers
{
    public class VerifyEmailCommandHandler(IUserRepository userRepository) : IRequestHandler<VerifyEmailCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken) ?? throw new Exception("User not found");
            if (user.EmailVerificationToken != request.Token)
                throw new Exception("Invalid verification token");

            user.IsEmailVerified = true;
            user.EmailVerificationToken = null;

            await _userRepository.UpdateUserAsync(user, user.Id, cancellationToken);

            return true;
        }
    }
}