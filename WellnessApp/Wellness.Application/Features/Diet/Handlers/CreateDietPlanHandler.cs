using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Features.Diet.Commands;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Diet.Handlers
{
    public class CreateDietPlanHandler(IDietRepository repository)
     : IRequestHandler<CreateDietPlanCommand, Guid>
    {
        private readonly IDietRepository _repository = repository;

        public async Task<Guid> Handle(
            CreateDietPlanCommand request,
            CancellationToken cancellationToken)
        {
            var dietPlan = new DietPlan
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
                Calories = request.Calories,
                CreatedDate = DateTime.UtcNow
            };

            await _repository.AddAsync(dietPlan, cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);

            return dietPlan.Id;
        }
    }
}
