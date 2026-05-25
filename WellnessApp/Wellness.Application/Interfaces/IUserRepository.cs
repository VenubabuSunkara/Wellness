using System;
using System.Collections.Generic;
using System.Text;
using Wellness.Domain.Entities;

namespace Wellness.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task AddAsync(User user, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateUserAsync(User user, Guid currentUserId, CancellationToken cancellationToken);

    }
}
