using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class Appointment:BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string DoctorName { get; set; } = default!;

        public string Notes { get; set; } = default!;

        public string Status { get; set; } = "Pending";

        public User User { get; set; } = default!;

    }
}
