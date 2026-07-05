using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Shared.ClientFactory
{
    public class ApiService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;
    }
}
