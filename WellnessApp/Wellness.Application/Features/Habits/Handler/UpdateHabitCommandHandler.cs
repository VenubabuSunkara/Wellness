using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Features.Habits.Commands;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Habits.Handler
{
    public sealed class UpdateHabitCommandHandler(IHabitRepository repository) : IRequestHandler<UpdateHabitCommand, bool>
    {
        private readonly IHabitRepository _repository = repository;

        public async Task<bool> Handle(UpdateHabitCommand request, CancellationToken cancellationToken)
        {
            var habit = await _repository.GetByIdAsync(request.Id);

            if (habit == null)
            {
                return false;
            }

            habit.Title = request.Title;

            await _repository.UpdateAsync(habit);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
