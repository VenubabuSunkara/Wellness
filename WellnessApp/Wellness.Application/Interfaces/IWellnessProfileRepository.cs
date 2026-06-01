using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Entities;

namespace Wellness.Application.Interfaces
{
    public interface IWellnessProfileRepository
    {
        Task AddAsync(WellnessProfile wellnessProfileEntry, CancellationToken cancellationToken = default);

        Task<List<WellnessProfile>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
