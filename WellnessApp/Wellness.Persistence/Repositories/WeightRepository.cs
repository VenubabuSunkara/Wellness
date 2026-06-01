using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;
using Wellness.Persistence.Context;

namespace Wellness.Persistence.Repositories
{
    public class WeightRepository(ApplicationDbContext context) : IWeightRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddAsync(
            WeightEntry weightEntry,
            CancellationToken cancellationToken = default)
        {
            await _context.WeightEntries
                .AddAsync(weightEntry, cancellationToken);
        }

        public Task<List<WeightEntry>> GetAllAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            return _context.WeightEntries
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.EntryDate)
                .ToListAsync(cancellationToken);
        }

        public Task SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
