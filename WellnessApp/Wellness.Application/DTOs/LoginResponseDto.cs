using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;
        public int UsertId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }
}
