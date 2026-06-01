using Wellness.Application.Features.Habits.DTOs;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Habits.Mappings
{
    public static class HabitMappings
    {
        public static HabitDto ToDto(this Habit habit)
        {
            return new HabitDto(
                habit.Id,
                habit.Title,
                habit.Description
            );
        }
    }
}
