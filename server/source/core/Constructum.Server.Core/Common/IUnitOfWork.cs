using FluentResults;

namespace Constructum.Server;

public interface IUnitOfWork
{
    ValueTask<Result<int>> SubmitChangesAsync(CancellationToken cancellationToken = default);
}