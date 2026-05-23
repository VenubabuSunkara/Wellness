using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Habit.Commands
{
    public class GetHabitsCommandHandler(
        IHabitRepository repository) : IRequestHandler<GetHabitsQuery, 
        List<Wellness.Domain.Entities.Habit>>
    {
        private readonly IHabitRepository _repository = repository;

        public Task<List<Wellness.Domain.Entities.Habit>> Handle(GetHabitsQuery request, CancellationToken cancellationToken) => _repository.GetAllAsync(request.UserId, cancellationToken);
    }
}
