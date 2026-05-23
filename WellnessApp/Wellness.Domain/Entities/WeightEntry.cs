using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class WeightEntry : BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; } = 0;
        public decimal BodyFatPercentage { get; set; } = 0;
        public decimal MuscleMass { get; set; } = 0;
        public decimal VisceralFat { get; set; } = 0;
        public decimal BasalMetabolicRate { get; set; } = 0;
        public int MetabolicAge { get; set; } = 0;
        public decimal TrunkFatPercentage { get; set; } = 0;
        public int BMI { get; set; } = 0;
        public DateTime EntryDate { get; set; }
        public User User { get; set; } = new User();
    }
}
