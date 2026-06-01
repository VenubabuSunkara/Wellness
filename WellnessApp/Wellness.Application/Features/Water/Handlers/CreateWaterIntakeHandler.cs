using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Features.Water.Commands;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Water.Handlers
{
    public class CreateWaterIntakeHandler(IGenericRepository<WaterIntake> repository) : IRequestHandler<CreateWaterIntakeCommand, Guid>
    {
        private readonly IGenericRepository<WaterIntake> _repository = repository;

        public async Task<Guid> Handle(CreateWaterIntakeCommand request, CancellationToken cancellationToken)
        {
            var water = new WaterIntake
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Liters = request.Liters,
                IntakeDate = DateTime.UtcNow
            };

            await _repository.AddAsync(water);
            return water.Id;
        }
    }

}
