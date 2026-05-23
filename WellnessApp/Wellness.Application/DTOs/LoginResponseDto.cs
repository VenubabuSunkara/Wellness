using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }
    }
}
