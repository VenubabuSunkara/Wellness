using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Habits.DTOs
{
    public sealed record HabitDto(
     Guid Id,
     string Name,
     string? Description);
}
