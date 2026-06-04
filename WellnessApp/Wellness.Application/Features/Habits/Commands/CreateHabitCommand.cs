using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Habits.Commands
{
    public sealed record CreateHabitCommand(Guid UserId, string Title) : IRequest<Guid>;
}
