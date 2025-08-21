using Church.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

  public DbSet<Asset> Assets { get; set; }
  public DbSet<AssetType> AssetsType { get; set; }
  public DbSet<Convention> Conventions { get; set; }
  public DbSet<ChurchRegister> Church { get; set; }
}
