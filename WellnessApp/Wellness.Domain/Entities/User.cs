using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public string Language { get; set; } = "en";
        public bool IsActive { get; set; } = true;
        public Guid TenantId { get; set; }

        public Tenant? Tenant { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
        public ICollection<Habit> Habits { get; set; } = [];
    }
}
