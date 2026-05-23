using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;

namespace Wellness.Application.Features.Roles.Commands
{
    public class DeleteRoleCommandHandler(
        IRoleRepository repository) : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IRoleRepository _repository = repository;

        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (role is null)
            {
                return false;
            }

            await _repository.DeleteAsync(role, cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
