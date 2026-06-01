using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Features.Weight.Commands;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Weight.Handler
{
    public class CreateWeightTrackingHandler(IGenericRepository<WeightTracking> repository) : IRequestHandler<CreateWeightTrackingCommand, Guid>
    {
        private readonly IGenericRepository<WeightTracking> _repository = repository;
        public async Task<Guid> Handle(CreateWeightTrackingCommand request, CancellationToken cancellationToken)
        {
            var weightTracking = new WeightTracking
            {
                UserId = request.UserId,
                Weight = request.Weight,
                CreatedDate = DateTime.UtcNow,
            };
            await _repository.AddAsync(weightTracking);
            return weightTracking.Id;
        }
    }
}
