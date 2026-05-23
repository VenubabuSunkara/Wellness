using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
