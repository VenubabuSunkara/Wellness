using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;
using Wellness.Persistence.Context;

namespace Wellness.Persistence.Repositories
{
    public class RoleRepository(ApplicationDbContext context) : IRoleRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddAsync(Role role, CancellationToken cancellationToken = default)
        {
            await _context.Roles
                .AddAsync(role, cancellationToken);
        }

        public Task UpdateAsync(Role role, CancellationToken cancellationToken = default)
        {
            role.UpdatedDate = DateTime.UtcNow;

            _context.Roles.Update(role);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(
            Role role,
            CancellationToken cancellationToken = default)
        {
            _context.Roles.Remove(role);

            return Task.CompletedTask;
        }

        public Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _context.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.Id == id,
                    cancellationToken);
        }

        public Task<List<Role>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _context.Roles
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
