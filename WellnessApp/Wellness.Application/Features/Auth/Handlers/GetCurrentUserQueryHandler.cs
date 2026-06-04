using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.DTOs;
using Wellness.Application.Features.Auth.Commands;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Auth.Handlers
{
    public class GetCurrentUserQueryHandler(
        IUserRepository userRepository) : IRequestHandler<GetCurrentUserQuery, UserProfileDto>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserProfileDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken) ?? throw new Exception("User not found");
            return new UserProfileDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}
