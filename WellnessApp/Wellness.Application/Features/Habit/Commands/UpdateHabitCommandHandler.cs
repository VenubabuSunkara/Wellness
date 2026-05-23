using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Habit.Commands
{
    public class UpdateHabitCommandHandler : IRequestHandler<UpdateHabitCommand, bool>
    {
        private readonly IHabitRepository _repository;

        public UpdateHabitCommandHandler(IHabitRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            UpdateHabitCommand request,
            CancellationToken cancellationToken)
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
