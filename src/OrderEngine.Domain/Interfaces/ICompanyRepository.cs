using OrderEngine.Domain.Entities;
using OrderEngine.Domain.Interfaces.Generics;

namespace OrderEngine.Domain.Interfaces;

public interface ICompanyRepository : IWriteGenericRepository<Company>, IReadGenericRepository<Company>
{
    
}