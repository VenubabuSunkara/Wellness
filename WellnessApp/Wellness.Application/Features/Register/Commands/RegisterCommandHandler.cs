using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Register.Commands
{
    public class RegisterCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterCommand, Guid>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Guid> Handle(
         RegisterCommand request,
         CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository
                .GetByEmailAsync(
                    request.Email,
                    cancellationToken);

            if (existingUser is not null)
            {
                throw new Exception("Email already exists");
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                IsActive = true
            };

            await _userRepository.AddAsync(user, cancellationToken);

            await _userRepository.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
