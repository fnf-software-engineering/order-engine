using Microsoft.EntityFrameworkCore;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Data;

public class OrderEngineDbContext : DbContext
{
    public OrderEngineDbContext(DbContextOptions<OrderEngineDbContext> options) : base(options)
    {
    }
    
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Branch> Branches => Set<Branch>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderEngineDbContext).Assembly);
    }
    
}