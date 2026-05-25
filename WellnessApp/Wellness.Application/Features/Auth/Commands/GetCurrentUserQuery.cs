using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.DTOs.Commands
{
    public class GetCurrentUserQuery : IRequest<UserProfileDto>
    {
        public Guid UserId { get; set; }
    }
}
