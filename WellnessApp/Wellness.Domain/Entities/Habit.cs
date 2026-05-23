using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class Habit : BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public string Title { get; set; } = string.Empty;   

        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public User User { get; set; } = new();

        public ICollection<HabitTracking> HabitTrackings { get; set; }= new HashSet<HabitTracking>();
    }
}
