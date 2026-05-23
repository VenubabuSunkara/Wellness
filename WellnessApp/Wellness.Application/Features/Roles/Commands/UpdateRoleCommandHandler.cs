using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Roles.Commands
{
    public class UpdateRoleCommandHandler(
        IRoleRepository repository) : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IRoleRepository _repository = repository;

        public async Task<bool> Handle(
            UpdateRoleCommand request,
            CancellationToken cancellationToken)
        {
            var role = await _repository
                .GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (role is null)
            {
                return false;
            }

            role.Name = request.Name;
            role.Description = request.Description;
            role.IsActive = request.IsActive;

            await _repository.UpdateAsync(role, cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}