using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.DTOs
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string Role { get; set; } = default!;
    }
}
