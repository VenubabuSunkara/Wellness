using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Entities;

namespace Wellness.Application.Interfaces
{
    public interface IDietRepository
    {
        Task AddAsync(
       DietPlan dietEntry,
       CancellationToken cancellationToken = default);

        Task<List<DietPlan>> GetAllAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        Task SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
