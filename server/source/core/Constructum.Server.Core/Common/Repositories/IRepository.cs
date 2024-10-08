using System.Linq.Expressions;
using Constructum.Server.Entities;
using FluentResults;

namespace Constructum.Server.Repositories;

public interface IReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
{
    ValueTask<Result<TEntity>> GetAsync(TKey id, CancellationToken cancellationToken = default);
    
    ValueTask<Result<TEntity>> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    ValueTask<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    
    ValueTask<IEnumerable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    ValueTask<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}

public interface IRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> , IUnitOfWork
    where TEntity : IEntity<TKey>
{
    ValueTask<Result> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    ValueTask<Result> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    ValueTask<Result> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
}