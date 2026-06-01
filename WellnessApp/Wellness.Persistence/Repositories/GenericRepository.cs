using Microsoft.EntityFrameworkCore;
using Wellness.Application.Interfaces;
using Wellness.Domain.Common;
using Wellness.Persistence.Context;

namespace Wellness.Persistence.Repositories;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : BaseEntity
{
    protected ApplicationDbContext Context { get; } = context;

    protected DbSet<T> DbSet { get; } = context.Set<T>();

    public ValueTask<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return new ValueTask<T?>(
            DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.Id == id && !x.IsDeleted,
                    cancellationToken));
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(
        T entity,
        CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default)
    {
        await DbSet.AddRangeAsync(entities, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAsync(
        T entity,
        CancellationToken cancellationToken = default)
    {
        DbSet.Update(entity);
        return Context.SaveChangesAsync(cancellationToken);
    }

    public Task DeleteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return DbSet
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(
                x => x.SetProperty(
                    p => p.IsDeleted,
                    true),
                cancellationToken);
    }

    public Task DeleteAsync(
        T entity,
        CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;

        DbSet.Update(entity);

        return Context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<T> Query()
        => DbSet
            .AsNoTracking()
            .Where(x => !x.IsDeleted);

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return DbSet
            .AnyAsync(
                x => x.Id == id && !x.IsDeleted,
                cancellationToken);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return Context.SaveChangesAsync(cancellationToken);
    }
}