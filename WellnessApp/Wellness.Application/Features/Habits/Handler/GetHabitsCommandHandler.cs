using MediatR;
using Wellness.Application.Features.Habits.DTOs;
using Wellness.Application.Features.Habits.Mappings;
using Wellness.Application.Features.Habits.Queries;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Habits.Handler
{
    public sealed class GetHabitsQueryHandler(IHabitRepository repository) : IRequestHandler<GetHabitsQuery, IReadOnlyList<HabitDto>>
    {
        private readonly IHabitRepository _habitRepository = repository;

        public async Task<IReadOnlyList<HabitDto>> Handle(GetHabitsQuery request, CancellationToken cancellationToken)
        {
            var habits = await _habitRepository.GetAllAsync(request.UserId, cancellationToken);
            return [.. habits.Select(x => x.ToDto())];
        }
    }
}
