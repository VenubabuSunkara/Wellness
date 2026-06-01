using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class WaterIntake:BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public double Liters { get; set; }

        public DateTime IntakeDate { get; set; }

        public User User { get; set; } = default!;

    }
}
