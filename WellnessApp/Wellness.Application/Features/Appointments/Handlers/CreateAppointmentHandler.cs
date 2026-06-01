using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Features.Appointments.Commands;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Appointments.Handlers
{
    public class CreateAppointmentHandler(IAppointmentRepository repository) : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        private readonly IAppointmentRepository _repository = repository;
        public async Task<Guid> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                AppointmentDate = request.AppointmentDate,
                CreatedBy = request.UserId,
                CreatedDate = DateTime.UtcNow,
                DoctorName = request.DoctorName,
                Notes = request.Notes,
                Status = "Scheduled",
                IsDeleted = false
            };

            await _repository.AddAsync(appointment, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return appointment.Id;
        }
    }
}
