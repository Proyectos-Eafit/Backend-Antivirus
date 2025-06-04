using Antivirus.Models;
using Microsoft.EntityFrameworkCore;

namespace Antivirus.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options) { }

    public DbSet<Bootcamp> Bootcamps { get; set; }
    public DbSet<InstituteBootcamp> InstituteBootcamps { get; set; }
    public DbSet<InstituteOpportunity> InstituteOpportunities { get; set; }
    public DbSet<Institution> Institutions { get; set; }
    public DbSet<Opportunity> Opportunities { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UbicationInstitution> UbicationInstitutions { get; set; }
    public DbSet<UserOpportunity> UserOpportunities { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserBootcamp> UserBootcamps { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Benefit> Benefits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Semilla de roles por defecto
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Usuario", Status = true },
            new Role { Id = 2, Name = "Admin", Status = true }
        );
    }
}