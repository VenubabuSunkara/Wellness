using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.DTOs.Commands
{
    public class VerifyEmailCommand : IRequest<bool>
    {
        public string Email { get; set; } = default!;

        public string Token { get; set; } = default!;
    }
}
