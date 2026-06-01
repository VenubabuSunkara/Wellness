using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Wellness.Commands
{
    public class CreateWellnessProfileCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public string Gender { get; set; } = default!;

        public string Goal { get; set; } = default!;

        public string ActivityLevel { get; set; } = default!;
    }

}
