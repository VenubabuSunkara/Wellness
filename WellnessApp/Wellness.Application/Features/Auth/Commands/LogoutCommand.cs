using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.DTOs.Commands
{
    public class LogoutCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }

        public string RefreshToken { get; set; } = default!;
    }
}
