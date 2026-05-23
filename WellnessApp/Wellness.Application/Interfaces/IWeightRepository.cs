using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Entities;

namespace Wellness.Application.Interfaces
{
    public interface IWeightRepository
    {
        Task AddAsync(
            WeightEntry weightEntry,
            CancellationToken cancellationToken = default);

        Task<List<WeightEntry>> GetAllAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        Task SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
