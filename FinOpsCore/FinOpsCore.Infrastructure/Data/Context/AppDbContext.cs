using FinOpsCore.Domain.Entities;
using FinOpsCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinOpsCore.Infrastructure.Data.Context;

public class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); 
        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result > 0; 
    }
}