using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wellness.Application.DTOs.Commands;
using Wellness.Application.Features.Register.Commands;

namespace Wellness.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // =========================
        // LOGIN
        // =========================
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        // =========================
        // REGISTER
        // =========================
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        // =========================
        // REFRESH TOKEN
        // =========================

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        // =========================
        // FORGOT PASSWORD
        // =========================
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(new
            {
                Success = true,
                Message = "Reset link sent successfully",
                Data = result
            });
        }
        // =========================
        // RESET PASSWORD
        // =========================
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(
            [FromBody] ResetPasswordCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(new
            {
                Success = true,
                Message = "Password reset successful",
                Data = result
            });
        }
        // =========================
        // CHANGE PASSWORD
        // =========================
        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(
            [FromBody] ChangePasswordCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(new
            {
                Success = true,
                Message = "Password changed successfully",
                Data = result
            });
        }

        // =========================
        // VERIFY EMAIL
        // =========================
        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmail(
            [FromQuery] VerifyEmailCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(new
            {
                Success = true,
                Message = "Email verified successfully",
                Data = result
            });
        }

        // =========================
        // RESEND OTP
        // =========================
        [HttpPost("resend-otp")]
        public async Task<IActionResult> ResendOtp(
            [FromBody] ResendOtpCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(new
            {
                Success = true,
                Message = "OTP sent successfully",
                Data = result
            });
        }

        // =========================
        // LOGOUT
        // =========================
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(
            [FromBody] LogoutCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(new
            {
                Success = true,
                Message = "Logout successful",
                Data = result
            });
        }

        // =========================
        // GET CURRENT USER
        // =========================
        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var userId = User.Claims.FirstOrDefault(x =>
                x.Type == "nameid")?.Value;

            var result = await _mediator.Send(
                new GetCurrentUserQuery
                {
                    UserId = Guid.Parse(userId!)
                });

            return Ok(new
            {
                Success = true,
                Data = result
            });
        }
    }

}
}
