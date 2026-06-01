using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class WellnessProfile:BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public string Gender { get; set; } = default!;

        public string Goal { get; set; } = default!;

        public string ActivityLevel { get; set; } = default!;

        public User User { get; set; } = default!;

    }
}
