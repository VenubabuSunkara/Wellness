using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Application.Interfaces;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Roles.Commands
{
    public class GetRolesQueryHandler(IRoleRepository repository) : IRequestHandler<GetRolesQuery, List<Role>>
    {
        private readonly IRoleRepository _repository = repository;

        public Task<List<Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return _repository
                .GetAllAsync(cancellationToken);
        }
    }
}
