using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.DTOs.Commands;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Auth.Handlers
{
    public class LogoutCommandHandler(IUserRepository userRepository) : IRequestHandler<LogoutCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> Handle(
            LogoutCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetByIdAsync(request.UserId) ?? throw new Exception("User not found");
            user.ResetToken = null;
            user.ResetTokenExpiry = null;
            await _userRepository.UpdateUserAsync(user, user.Id, cancellationToken);

            return true;
        }
    }
}
