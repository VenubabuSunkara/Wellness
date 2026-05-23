using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.DTOs;

namespace Wellness.Application.Features.Auth.Commands
{
    public class LoginCommand : IRequest<LoginResponseDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
