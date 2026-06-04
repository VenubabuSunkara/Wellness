using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.DTOs;

namespace Wellness.Application.Features.Auth.Commands
{
    public class GetCurrentUserQuery : IRequest<UserProfileDto>
    {
        public Guid UserId { get; set; }
    }
}
