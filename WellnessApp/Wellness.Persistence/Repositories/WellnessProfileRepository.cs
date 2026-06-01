using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;
using Wellness.Persistence.Context;

namespace Wellness.Persistence.Repositories
{
    public class WellnessProfileRepository(ApplicationDbContext context) : IWellnessProfileRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddAsync(WellnessProfile wellnessProfileEntry, CancellationToken cancellationToken = default)
        {
            await _context.WellnessProfiles.AddAsync(wellnessProfileEntry, cancellationToken);
        }

        public Task<List<WellnessProfile>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return _context.WellnessProfiles
                  .AsNoTracking()
                  .Where(x => x.UserId == userId)
                  .OrderByDescending(x => x.UpdatedDate)
                  .ToListAsync(cancellationToken);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
