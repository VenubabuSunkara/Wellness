using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Roles.Commands
{
    public class CreateRoleCommandHandler(IRoleRepository repository) : IRequestHandler<CreateRoleCommand, Guid>
    {
        private readonly IRoleRepository _repository = repository;

        public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role
            {
                Name = request.Name
            };

            await _repository.AddAsync(role, cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);

            return role.Id;
        }
    }
}