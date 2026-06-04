using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Auth.Commands
{
    public sealed record ChangePasswordCommand(Guid UserId, string CurrentPassword, string NewPassword) : IRequest<bool>;
}
