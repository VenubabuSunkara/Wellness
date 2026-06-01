using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Features.Habits.DTOs;

namespace Wellness.Application.Features.Habits.Queries
{
    public sealed record GetHabitsQuery(Guid UserId) : IRequest<IReadOnlyList<HabitDto>>;
}
