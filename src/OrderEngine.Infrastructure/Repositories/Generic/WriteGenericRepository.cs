using OrderEngine.Domain.Interfaces.Generics;

namespace OrderEngine.Infrastructure.Repositories.Generic;

public class WriteGenericRepository<T> : IWriteGenericRepository<T> where T : class
{
    public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}