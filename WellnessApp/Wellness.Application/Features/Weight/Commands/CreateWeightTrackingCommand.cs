using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Weight.Commands
{
    public class CreateWeightTrackingCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public double Weight { get; set; }
    }

}
