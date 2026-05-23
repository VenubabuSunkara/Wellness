using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class HabitTracking : BaseEntity
    {
        [ForeignKey("Habit")]
        public Guid HabitId { get; set; }

        public DateTime TrackingDate { get; set; }= DateTime.Now;

        public bool IsCompleted { get; set; }=false;

        public Habit Habit { get; set; } = new();
    }
}
