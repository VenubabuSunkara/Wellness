using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Entities;

namespace Wellness.Application.Interfaces
{
    public interface IHabitRepository
    {
        Task AddAsync(Habit habit);

        Task UpdateAsync(Habit habit);

        Task DeleteAsync(Habit habit);

        Task<Habit> GetByIdAsync(Guid id);

        Task<List<Habit>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);

        Task SaveChangesAsync();
    }
}
