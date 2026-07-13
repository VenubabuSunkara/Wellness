using Wellness.Web.ViewModels;

namespace Wellness.Web.Services.Interface
{
    public interface IWeightService
    {
        Task SaveWeightTrackingAsync(WeightTrackingViewModel weightTracking);
        Task SaveWeightAsync(WeightRequestViewModel weightRequest);
        Task DeleteWeightAsync(int weightId);
        Task UpdateWeightAsync(WeightRequestViewModel weightRequest);
        Task<WeightRequestViewModel> GetWeightByUserIdAsync(int userId);
        Task<WeightRequestViewModel> GetAllWeights(int PageNumber, int PageSize);
    }
}
