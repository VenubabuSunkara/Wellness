using MediatR;
using Wellness.Application.Features.Habits.Commands;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;
namespace Wellness.Application.Features.Habits.Handler
{
    public sealed class CreateHabitCommandHandler(IHabitRepository habitRepository) : IRequestHandler<CreateHabitCommand, Guid>
    {
        private readonly IHabitRepository _habitRepository = habitRepository;

        public async Task<Guid> Handle(CreateHabitCommand request, CancellationToken cancellationToken)
        {
            var habit = new Habit
            {
                UserId = request.UserId,
                Title = request.Title,
                IsActive = true
            };

            await _habitRepository.AddAsync(habit);
            await _habitRepository.SaveChangesAsync();
            return habit.Id;
        }
    }
}
