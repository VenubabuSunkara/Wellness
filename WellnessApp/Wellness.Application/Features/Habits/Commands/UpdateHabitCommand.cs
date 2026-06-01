using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Habits.Commands
{
    public class UpdateHabitCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;
    }
}
