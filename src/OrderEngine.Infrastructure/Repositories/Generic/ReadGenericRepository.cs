using System.Linq.Expressions;
using OrderEngine.Domain.Interfaces.Generics;

namespace OrderEngine.Infrastructure.Repositories.Generic;

public class ReadGenericRepository<T> : IReadGenericRepository<T> where T : class
{
    public Task<T?> GetByIdAsync(object[] keyValues, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}