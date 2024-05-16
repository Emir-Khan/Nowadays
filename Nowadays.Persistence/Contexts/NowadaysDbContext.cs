using Microsoft.EntityFrameworkCore;
using Nowadays.Domain.Entities;
using Nowadays.Domain.Entities.Common;

namespace Nowadays.Persistence.Contexts
{
  public class NowadaysDbContext : DbContext
  {
    public NowadaysDbContext(DbContextOptions<NowadaysDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Issue> Issues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Project>()
        .HasOne(p => p.Company)
        .WithMany(c => c.Projects)
        .HasForeignKey(p => p.CompanyId);

      modelBuilder.Entity<Issue>()
        .HasOne(i => i.Project)
        .WithMany(p => p.Issues)
        .HasForeignKey(i => i.ProjectId);

      base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

      var datas = ChangeTracker
           .Entries<BaseEntity>();

      foreach (var data in datas)
      {
        _ = data.State switch
        {
          EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
          EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
          _ => DateTime.Now
        };
      }

      return await base.SaveChangesAsync(cancellationToken);
    }
  }
}
