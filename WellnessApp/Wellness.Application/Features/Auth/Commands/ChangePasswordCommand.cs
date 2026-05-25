using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.DTOs.Commands
{
    public class ChangePasswordCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }

        public string CurrentPassword { get; set; } = default!;

        public string NewPassword { get; set; } = default!;
    }
}
