using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;
using Wellness.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace Wellness.Persistence.Repositories
{
    public class DietRepository(ApplicationDbContext context) : IDietRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task AddAsync(DietPlan dietEntry, CancellationToken cancellationToken = default)
        {
            await _context.DietPlans
                .AddAsync(dietEntry , cancellationToken);
        }

        public Task<List<DietPlan>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return _context.DietPlans
                .Where(d => d.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
