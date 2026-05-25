using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.DTOs.Commands;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Auth.Handlers
{
    public class ChangePasswordCommandHandler(IUserRepository userRepository) : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken) ?? throw new Exception("User not found");
            bool validPassword = BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash);

            if (!validPassword)
                throw new Exception("Current password incorrect");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

            await _userRepository.UpdateUserAsync(user, user.Id, cancellationToken);

            return true;
        }
    }
}
