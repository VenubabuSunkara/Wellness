using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string password);

        bool VerifyPassword(string hashedPassword, string password);
    }

}
