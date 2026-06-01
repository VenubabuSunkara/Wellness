using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.DTOs;

namespace Wellness.Application.Features.Dashboard
{
    public class GetDashboardQuery : IRequest<DashboardDto>
    {
        public Guid UserId { get; set; }
    }
}
