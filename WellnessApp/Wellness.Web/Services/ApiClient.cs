using System.Text.Json;
using Wellness.Web.Services.Interface;
using Wellness.Web.ViewModels;

namespace Wellness.Web.Services
{
    public class ApiClient(HttpClient httpClient) : IApiClient
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<ApiResponse<bool>> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);

            return await HandleResponse<bool>(response);
        }

        public async Task<ApiResponse<TResponse>> GetAsync<TResponse>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            return await HandleResponse<TResponse>(response);
        }

        public async Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(string url, TRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync(url, request);

            return await HandleResponse<TResponse>(response);
        }

        public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(url, request);
            return await HandleResponse<TResponse>(response);
        }
        private async Task<ApiResponse<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            var apiResponse = await response.Content
                .ReadFromJsonAsync<ApiResponse<T>>(new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (apiResponse == null)
                throw new Exception("Unable to read API response.");

            if (!apiResponse.Success)
            {
                var errorMessage = apiResponse.Errors.Any()
                    ? string.Join(Environment.NewLine, apiResponse.Errors)
                    : apiResponse.Message;

                throw new Exception(errorMessage);
            }

            return apiResponse;
        }
    }
}
