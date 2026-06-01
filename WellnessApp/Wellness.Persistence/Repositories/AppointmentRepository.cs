using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;
using Wellness.Persistence.Context;

namespace Wellness.Persistence.Repositories
{
    public class AppointmentRepository(ApplicationDbContext context) : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task AddAsync(Appointment appointment, CancellationToken cancellationToken = default)
        {
            await _context.Appointments.AddAsync(appointment, cancellationToken);
        }

        public Task<List<Appointment>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return _context.Appointments.AsNoTracking().Where(x => x.UserId == userId)
                .OrderByDescending(x => x.AppointmentDate).ToListAsync(cancellationToken);

        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
