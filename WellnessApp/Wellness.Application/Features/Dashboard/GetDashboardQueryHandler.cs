using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.DTOs;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Dashboard
{
    public class GetDashboardQueryHandler(
        IUserRepository userRepository,
        IHabitRepository habitRepository)
          : IRequestHandler<GetDashboardQuery, DashboardDto>
    {
        private readonly IUserRepository _userRepository = userRepository;

        private readonly IHabitRepository _habitRepository = habitRepository;

        public async Task<DashboardDto> Handle(
            GetDashboardQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetByIdAsync(
                    request.UserId,
                    cancellationToken);

            var habits = await _habitRepository
                .GetAllAsync(
                    request.UserId,
                    cancellationToken);

            return new DashboardDto
            {
                TotalHabits = habits.Count,
                CompletedHabits = habits.Count(x => x.IsActive),
                StreakDays = 10
            };
        }
    }
}