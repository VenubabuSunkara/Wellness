using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class DietPlan : BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public string Title { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int Calories { get; set; }


        public User User { get; set; } = default!;

    }
}
