using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Habit.Commands
{
    public class DeleteHabitCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
