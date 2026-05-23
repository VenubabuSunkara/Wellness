using MediatR;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Habit.Commands
{
    public class CreateHabitCommandHandler : IRequestHandler<CreateHabitCommand, Guid>
    {
        private readonly IHabitRepository _habitRepository;

        public CreateHabitCommandHandler(IHabitRepository habitRepository) => _habitRepository = habitRepository;

        public async Task<Guid> Handle(CreateHabitCommand request, CancellationToken cancellationToken)
        {
            var habit = new Wellness.Domain.Entities.Habit
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
