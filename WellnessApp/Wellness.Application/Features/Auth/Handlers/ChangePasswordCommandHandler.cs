using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Features.Auth.Commands;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Auth.Handlers
{
    public sealed class ChangePasswordCommandHandler(IUserRepository userRepository, IPasswordService passwordService) : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordService _passwordService = passwordService;

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken) ?? throw new Exception("User not found");
            bool validPassword = _passwordService.VerifyPassword(request.CurrentPassword, user.PasswordHash);

            if (!validPassword)
                throw new Exception("Current password incorrect");

            user.PasswordHash = _passwordService.HashPassword(request.NewPassword);
            await _userRepository.UpdateUserAsync(user, user.Id, cancellationToken);
            return true;
        }
    }
}
