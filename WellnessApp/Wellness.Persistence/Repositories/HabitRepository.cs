using Microsoft.EntityFrameworkCore;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;
using Wellness.Persistence.Context;

namespace Wellness.Persistence.Repositories
{
    public class HabitRepository(ApplicationDbContext context) : IHabitRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddAsync(Habit habit)
        {
            await _context.Habits.AddAsync(habit);
        }

        public Task UpdateAsync(Habit habit)
        {
            ArgumentNullException.ThrowIfNull(habit);

            return _context.Habits
                .Where(x => x.Id == habit.Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.Title, habit.Title ?? string.Empty)
                    .SetProperty(x => x.Description, habit.Description)
                    .SetProperty(x => x.IsActive, habit.IsActive)
                    .SetProperty(x => x.UpdatedDate, DateTime.UtcNow));
        }

        public Task DeleteAsync(Habit habit)
        {
            return _context.Habits.Where(x => x.Id == habit.Id).ExecuteDeleteAsync();
        }

        public async Task<Habit> GetByIdAsync(Guid id)
        {
            var habit = await _context.Habits.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return habit is null ? throw new Exception("Habit not found") : habit;
        }

        public Task<List<Habit>> GetAllAsync(Guid userId)
        {
            return _context.Habits
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<List<Habit>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
