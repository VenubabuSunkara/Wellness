using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Weight.Commands
{
    public class CreateWeightCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public decimal Weight { get; set; }
    }
}
