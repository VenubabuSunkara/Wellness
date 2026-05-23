using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Contracts.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
