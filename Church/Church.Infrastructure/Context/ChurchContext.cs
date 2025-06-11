using Church.Domain.Entities;

namespace Church.Infrastructure.Context;

public class ChurchContext : DbContext
{
  public ChurchContext(DbContextOptions<ChurchContext> options)
      : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChurchContext).Assembly);
  }

  public DbSet<Asset> Asset { get; set; }
  public DbSet<Church> Church { get; set; }
  public DbSet<Convention> Convention { get; set; }
  public DbSet<Convention> Convention { get; set; }
}
