using System;
using System.ComponentModel.DataAnnotations.Schema;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class RolePermission : BaseEntity
    {
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }

        [ForeignKey("Permission")]
        public Guid PermissionId { get; set; }

        public Role? Role { get; set; }

        public Permission? Permission { get; set; }
    }
}
