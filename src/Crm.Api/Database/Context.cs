using Crm.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crm.Api.Database;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Contact> Contacts { get; init; }
    public DbSet<Sector> Sectors { get; init; }
    public DbSet<LeadOrigin> LeadOrigins { get; init; }
    public DbSet<Category> Categories { get; init; }
    public DbSet<Organization> Organizations { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.HasOne(p => p.LeadOrigin).WithMany().OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(p => p.Category).WithMany().OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.HasOne(p => p.LeadOrigin).WithMany().OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(p => p.Category).WithMany().OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(p => p.Sector).WithMany().OnDelete(DeleteBehavior.Restrict);
        });
    }
}
