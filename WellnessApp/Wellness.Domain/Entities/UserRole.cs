using System;
using System.ComponentModel.DataAnnotations.Schema;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [ForeignKey("Role")]
        public Guid RoleId { get; set; }

        public User? User { get; set; }

        public Role? Role { get; set; }
    }
}
