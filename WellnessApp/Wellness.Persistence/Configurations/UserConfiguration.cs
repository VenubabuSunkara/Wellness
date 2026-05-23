using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Entities;

namespace Wellness.Persistence.Configurations
{
    public class UserConfiguration
      : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
           .HasMaxLength(100);

            builder.Property(x => x.Email)
                .HasMaxLength(200);

            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(x => x.PhoneNumber)
           .HasMaxLength(20);

            builder.Property(x => x.Language)
                .HasMaxLength(10);
        }
    }
}
