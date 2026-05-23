using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;

namespace Wellness.Infrastructure.Services
{
    public class OpenAiService : IOpenAiService
    {
        private readonly HttpClient _httpClient;

        public OpenAiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AskAi(string question)
        {
            return "AI Response";
        }
    }
}
