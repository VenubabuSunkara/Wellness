using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.DTOs.Commands
{
    public class ResendOtpCommand : IRequest<bool>
    {
        public string Email { get; set; } = default!;
    }
}
