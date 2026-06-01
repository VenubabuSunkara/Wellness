using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Shared.Common;

namespace Wellness.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<ApiResponse<Guid>>
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Language { get; set; } = "en";
    }
}
