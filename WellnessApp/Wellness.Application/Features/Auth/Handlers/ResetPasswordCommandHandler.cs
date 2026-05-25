using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.DTOs.Commands;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Auth.Handlers
{
    public class ResetPasswordCommandHandler(IUserRepository userRepository) : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetByEmailAsync(request.Email, cancellationToken);

            if (user == null)
                throw new Exception("User not found");

            if (user.ResetToken != request.Token)
                throw new Exception("Invalid token");

            if (user.ResetTokenExpiry < DateTime.UtcNow)
                throw new Exception("Token expired");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

            user.ResetToken = null;
            user.ResetTokenExpiry = null;

            await _userRepository.UpdateUserAsync(user, user.Id, cancellationToken);

            return true;
        }
    }
}
