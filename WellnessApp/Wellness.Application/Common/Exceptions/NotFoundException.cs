using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string name, object key)
            : base($"{name} with value ({key}) was not found.")
        {
        }
    }
}
