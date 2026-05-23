using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Habit.Commands
{
    public class DeleteHabitCommandHandler : IRequestHandler<DeleteHabitCommand, bool>
    {
        private readonly IHabitRepository _repository;

        public DeleteHabitCommandHandler(IHabitRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            DeleteHabitCommand request,
            CancellationToken cancellationToken)
        {
            var habit = await _repository
                .GetByIdAsync(request.Id);

            if (habit == null)
            {
                return false;
            }

            await _repository.DeleteAsync(habit);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
