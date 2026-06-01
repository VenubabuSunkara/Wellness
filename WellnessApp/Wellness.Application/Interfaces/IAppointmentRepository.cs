using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Entities;

namespace Wellness.Application.Interfaces
{
    public interface IAppointmentRepository
    {
        Task AddAsync(
            Appointment appointment,
            CancellationToken cancellationToken = default);

        Task<List<Appointment>> GetAllAsync(
            Guid userId,
            CancellationToken cancellationToken = default);

        Task SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
