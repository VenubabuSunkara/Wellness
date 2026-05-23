using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Entities;

namespace Wellness.Application.Features.Roles.Commands
{
    public class GetRolesQuery : IRequest<List<Role>>
    {
    }
}
