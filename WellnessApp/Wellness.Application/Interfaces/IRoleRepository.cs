using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Entities;

namespace Wellness.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task AddAsync(Role role, CancellationToken cancellationToken = default);

        Task UpdateAsync(
            Role role,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            Role role,
            CancellationToken cancellationToken = default);

        Task<Role?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<List<Role>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
