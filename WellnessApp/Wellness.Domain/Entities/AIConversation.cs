using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wellness.Domain.Common;

namespace Wellness.Domain.Entities
{
    public class AIConversation : BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public string UserQuestion { get; set; } = string.Empty;

        public string AIResponse { get; set; }= string.Empty;

        public User User { get; set; } = new User();
    }
}
