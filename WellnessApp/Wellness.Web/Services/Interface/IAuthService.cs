using Microsoft.AspNetCore.Identity.Data;
using Wellness.Application.DTOs;
using Wellness.Web.ViewModels;

namespace Wellness.Web.Services.Interface
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> LoginAsync(LoginViewModel request);
    }
}
