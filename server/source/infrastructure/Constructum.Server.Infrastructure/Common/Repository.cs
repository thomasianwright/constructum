using System.Linq.Expressions;
using Constructum.Server.Entities;
using Constructum.Server.Repositories;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Constructum.Server;

public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : struct
{
    protected ApplicationDbContext Context { get; }
    
    protected DbSet<TEntity> Set => Context.Set<TEntity>();
    
    protected Repository(ApplicationDbContext context)
    {
        Context = context;
    }

    public virtual async ValueTask<Result<TEntity>> GetAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity = await Set.FindAsync(new object[] { id }, cancellationToken);
        
        if (entity == null)
        {
            return Result.Fail<TEntity>($"Entity with id {id} not found.");
        }
        
        return Result.Ok(entity);
    }

    public virtual async ValueTask<Result<TEntity>> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var entity = await Set.SingleOrDefaultAsync(predicate, cancellationToken);
        
        if (entity == null)
        {
            return Result.Fail<TEntity>($"Entity not found.");
        }
        
        return Result.Ok(entity);
    }

    public virtual async ValueTask<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await Set.ToListAsync(cancellationToken);
        
        return entities;
    }

    public virtual async ValueTask<IEnumerable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var entities = await Set.Where(predicate)
            .ToListAsync(cancellationToken);
        
        return entities;
    }

    public virtual async ValueTask<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Set.AnyAsync(predicate, cancellationToken);
    }

    public virtual async ValueTask<Result> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Set.AddAsync(entity, cancellationToken);
        
        return Result.Ok();
    }

    public virtual ValueTask<Result> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Set.Update(entity);
        
        return ValueTask.FromResult(Result.Ok());
    }

    public virtual async ValueTask<Result> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity = await Set.FindAsync(new object[] { id }, cancellationToken);
        
        if (entity == null)
        {
            return Result.Fail($"Entity with id {id} not found.");
        }
        
        Set.Remove(entity);
        
        return Result.Ok();
    }
    
    public virtual async ValueTask<Result<int>> SubmitChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return Result.Ok(await Context.SaveChangesAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return Result.Fail<int>(ex.Message);
        }
    }
}