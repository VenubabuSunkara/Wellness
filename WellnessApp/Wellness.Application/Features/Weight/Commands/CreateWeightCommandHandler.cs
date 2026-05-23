using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Weight.Commands
{
    public class CreateWeightCommandHandler(IWeightRepository repository) : IRequestHandler<CreateWeightCommand, Guid>
    {
        private readonly IWeightRepository _repository = repository;

        public async Task<Guid> Handle(
            CreateWeightCommand request,
            CancellationToken cancellationToken)
        {
            var weight = new WeightEntry
            {
                UserId = request.UserId,
                Weight = request.Weight,
                EntryDate = DateTime.UtcNow
            };

            await _repository.AddAsync(
                weight,
                cancellationToken);

            await _repository.SaveChangesAsync(
                cancellationToken);

            return weight.Id;
        }
    }
}