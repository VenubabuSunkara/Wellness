using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Features.Habits.Commands;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Habits.Handler
{
    public sealed class DeleteHabitCommandHandler(IHabitRepository repository) : IRequestHandler<DeleteHabitCommand, bool>
    {
        private readonly IHabitRepository _repository = repository;

        public async Task<bool> Handle(DeleteHabitCommand request, CancellationToken cancellationToken)
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
