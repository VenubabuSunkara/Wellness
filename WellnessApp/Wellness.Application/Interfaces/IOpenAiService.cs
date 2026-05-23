using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Interfaces
{
    public interface IOpenAiService
    {
        Task<string> AskAi(string question);
    }
}
