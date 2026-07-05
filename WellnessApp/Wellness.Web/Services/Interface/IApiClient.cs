using Wellness.Web.ViewModels;

namespace Wellness.Web.Services.Interface
{
    public interface IApiClient
    {
        Task<ApiResponse<TResponse>> GetAsync<TResponse>(string url);

        Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(
            string url,
            TRequest request);

        Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(
            string url,
            TRequest request);

        Task<ApiResponse<bool>> DeleteAsync(string url);
    }
}
