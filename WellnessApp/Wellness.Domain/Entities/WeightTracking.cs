using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class WeightTracking:BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public double Weight { get; set; }

        public DateTime RecordDate { get; set; }

        public User User { get; set; } = default!;

    }
}
