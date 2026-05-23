using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Dashboard
{
    public class GetDashboardQuery : IRequest<Wellness.Application.DTOs.DashboardDto>
    {
        public Guid UserId { get; set; }
    }
}
