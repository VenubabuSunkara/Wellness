using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Appointments.Commands
{
    public class CreateAppointmentCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string DoctorName { get; set; } = default!;

        public string Notes { get; set; } = default!;
    }
}
