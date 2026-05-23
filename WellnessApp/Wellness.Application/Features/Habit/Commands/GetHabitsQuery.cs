using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Habit.Commands
{
    public class GetHabitsQuery : IRequest<List<Wellness.Domain.Entities.Habit>>
    {
        public Guid UserId { get; set; }
    }
}
