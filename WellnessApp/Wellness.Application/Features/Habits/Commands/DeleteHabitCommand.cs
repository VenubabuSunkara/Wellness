using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Habits.Commands
{
    public sealed record DeleteHabitCommand(Guid Id) : IRequest<bool>;
}
