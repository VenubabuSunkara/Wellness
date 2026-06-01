using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Features.Wellness.Commands;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Wellness.Handlers
{
    public class CreateWellnessProfileHandler(IWellnessProfileRepository repository) : IRequestHandler<CreateWellnessProfileCommand, Guid>
    {
        private readonly IWellnessProfileRepository _repository = repository;

        public async Task<Guid> Handle(CreateWellnessProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = new WellnessProfile
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Age = request.Age,
                Height = request.Height,
                Weight = request.Weight,
                Gender = request.Gender,
                Goal = request.Goal,
                ActivityLevel = request.ActivityLevel,
                CreatedDate = DateTime.UtcNow
            };

            await _repository.AddAsync(profile, cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);

            return profile.Id;
        }
    }

}
