using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.DTOs.Commands
{
    public class ResetPasswordCommand : IRequest<bool>
    {
        public string Email { get; set; } = default!;

        public string Token { get; set; } = default!;

        public string NewPassword { get; set; } = default!;
    }
}
