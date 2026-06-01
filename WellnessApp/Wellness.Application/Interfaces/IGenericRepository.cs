using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Application.Interfaces
{
    public interface IGenericRepository<T>
      where T : BaseEntity
    {
        ValueTask<T?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task AddAsync(
            T entity,
            CancellationToken cancellationToken = default);

        Task AddRangeAsync(
            IEnumerable<T> entities,
            CancellationToken cancellationToken = default);

        Task UpdateAsync(
            T entity,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            T entity,
            CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        IQueryable<T> Query();

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
