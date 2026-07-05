using Wellness.Application.DTOs;
using Wellness.Web.Services.Interface;
using Wellness.Web.ViewModels;

namespace Wellness.Web.Services
{
    public class AuthService(IApiClient apiClient) : IAuthService
    {
        private readonly IApiClient _apiClient = apiClient;

        public async Task<LoginResponseDto> LoginAsync(LoginViewModel model)
        {
            var response = await _apiClient.PostAsync<LoginViewModel, LoginResponseDto>(
                "api/auth/login",
                model);

            if (response?.Data == null)
                throw new InvalidOperationException($"Login failed. Status: {response?.StatusCode}. Message: {response?.Message}");

            return response.Data;
        }
    }
}
