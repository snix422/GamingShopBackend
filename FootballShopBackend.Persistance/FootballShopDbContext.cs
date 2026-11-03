using FootballShopBackend.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FootballShopBackend.Persistance;

public class FootballShopDbContext : IdentityDbContext<ApplicationUser>
{
    public FootballShopDbContext(DbContextOptions<FootballShopDbContext> options) : base(options)
    {

    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FootballShopDbContext).Assembly);
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        // Seed data for Authors
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "John Doe" },
            new Author { Id = 2, Name = "Jane Smith" }
        );
        // Seed data for Leagues
        modelBuilder.Entity<League>().HasData(
            new League { Id = 1, Name = "Premier League" },
            new League { Id = 2, Name = "La Liga" }
        );
        // Seed data for Teams
        modelBuilder.Entity<Team>().HasData(
            new Team { Id = 1, Name = "Manchester United", LeagueId = 1 },
            new Team { Id = 2, Name = "Real Madrid", LeagueId = 2 }
        );
        // Seed data for Products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Football Jersey", Price = 49.99m, TeamId = 1 },
            new Product { Id = 2, Name = "Football Boots", Price = 89.99m, TeamId = 2 }
        );
        // Seed data for Reviews
        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, ProductId = 1, Rating = 5, Comment = "Great quality!" },
            new Review { Id = 2, ProductId = 2, Rating = 4, Comment = "Very comfortable." }
        );
    })

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            
            
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
