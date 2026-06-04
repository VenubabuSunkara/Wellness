using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Auth.Commands
{
    public sealed record LogoutCommand(Guid UserId, string RefreshToken) : IRequest<bool>;
}
