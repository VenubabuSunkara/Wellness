using MediatR;
using Wellness.Application.DTOs;

namespace Wellness.Application.DTOs.Commands
{
    public class RefreshTokenCommand : IRequest<LoginResponseDto>
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
