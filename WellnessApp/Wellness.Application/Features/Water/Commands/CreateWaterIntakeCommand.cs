using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Water.Commands
{
    public class CreateWaterIntakeCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public double Liters { get; set; }
    }

}
