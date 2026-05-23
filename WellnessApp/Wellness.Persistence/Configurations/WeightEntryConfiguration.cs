using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Entities;

namespace Wellness.Persistence.Configurations
{
    public class WeightEntryConfiguration
      : IEntityTypeConfiguration<WeightEntry>
    {
        public void Configure(
            EntityTypeBuilder<WeightEntry> builder)
        {
            builder.ToTable("WeightEntries");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Weight)
                .HasPrecision(18, 2);

            builder.Property(x => x.BodyFatPercentage)
                .HasPrecision(18, 2);

            builder.Property(x => x.BasalMetabolicRate)
                .HasPrecision(18);

            builder.Property(x => x.MuscleMass)
                .HasPrecision(18, 2);

            builder.Property(x => x.TrunkFatPercentage)
                .HasPrecision(18, 2);

            builder.Property(x => x.VisceralFat)
                .HasPrecision(18, 2);

            builder.Property(x => x.MetabolicAge)
                .HasPrecision(18);

            builder.Property(x => x.BMI)
                .HasPrecision(18, 2);
        }
    }
}
