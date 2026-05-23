using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class JournalEntry : BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public string Gratitude { get; set; } = string.Empty;       

        public string OneGoodThing { get; set; } = string.Empty;

        public string TomorrowGoal { get; set; } = string.Empty;

        public User User { get; set; } = new User();
    }
}
