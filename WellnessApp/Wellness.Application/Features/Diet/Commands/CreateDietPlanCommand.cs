using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.Features.Diet.Commands
{
    public class CreateDietPlanCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public string Title { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int Calories { get; set; }
    }

}
