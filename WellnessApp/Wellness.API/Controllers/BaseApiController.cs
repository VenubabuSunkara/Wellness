using Microsoft.AspNetCore.Mvc;
using Wellness.Shared.Common;

namespace Wellness.API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected IActionResult Success<T>(T data, string message = "Success")
        {
            return Ok(new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            });
        }
        protected IActionResult Failure(string message, List<string>? errors = null)
        {
            return BadRequest(new ApiResponse<object>
            {
                Success = false,
                Message = message,
                Errors = errors ?? new()
            });
        }
    }
}
