using Wellness.Web.Services.Interface;
using Wellness.Web.ViewModels;

namespace Wellness.Web.Services
{
    public class WeightService(IApiClient apiClient) : IWeightService
    {
        private readonly IApiClient _apiClient = apiClient;

        public async Task SaveWeightAsync(WeightRequestViewModel weightRequest)
        {
            var response = await _apiClient.PostAsync<WeightRequestViewModel, int>(
                "api/weight/save",
                weightRequest);

            if (response?.Data == 0)
                throw new InvalidOperationException($"Failed to save weight. Status: {response?.StatusCode}. Message: {response?.Message}");

        }

        public async Task SaveWeightTrackingAsync(WeightTrackingViewModel weightTracking)
        {
            var response = await _apiClient.PostAsync<WeightTrackingViewModel, int>(
                "api/weighttracking/save",
                weightTracking);

            if (response?.Data == 0)
                throw new InvalidOperationException($"Failed to save weight. Status: {response?.StatusCode}. Message: {response?.Message}");
        }
        public async Task UpdateWeightAsync(WeightRequestViewModel weightRequest)
        {
            var response = await _apiClient.PutAsync<WeightRequestViewModel, int>(
                "api/weight/update",
                weightRequest);
            if (response?.Data == 0)
                throw new InvalidOperationException($"Failed to update weight. Status: {response?.StatusCode}. Message: {response?.Message}");
        }
        public async Task DeleteWeightAsync(int weightId)
        {
            var response = await _apiClient.DeleteAsync($"api/weight/delete/{weightId}");
            if (response?.Data == false)
                throw new InvalidOperationException($"Failed to delete weight. Status: {response?.StatusCode}. Message: {response?.Message}");
        }

        public async Task<WeightRequestViewModel> GetWeightByUserIdAsync(int userId)
        {
            var response = await _apiClient.GetAsync<WeightRequestViewModel>($"api/weight/user/{userId}");
            if (response?.Data == null)
                throw new InvalidOperationException($"Failed to retrieve weight. Status: {response?.StatusCode}. Message: {response?.Message}");
            return response.Data;   
        }

        public async Task<WeightRequestViewModel> GetAllWeights(int PageNumber, int PageSize)
        {
            var response = await _apiClient.GetAsync<WeightRequestViewModel>($"api/weight/all?pageNumber={PageNumber}&pageSize={PageSize}");
            if (response?.Data == null)
                throw new InvalidOperationException($"Failed to retrieve weights. Status: {response?.StatusCode}. Message: {response?.Message}");
            return response.Data;
        }
    }
