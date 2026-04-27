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
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<ThirdBranch> ThirdBranches => Set<ThirdBranch>();
    public DbSet<ThirdParty> ThirdParties => Set<ThirdParty>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderEngineDbContext).Assembly);
    }
    
}