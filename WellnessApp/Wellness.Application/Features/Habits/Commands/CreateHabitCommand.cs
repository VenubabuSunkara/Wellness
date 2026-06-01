using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Habits.Commands
{
    public class CreateHabitCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public string Title { get; set; } = default!;
    }
}
