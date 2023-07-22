using CSharp.GraphQL.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp.GraphQL.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.SoldBy).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(1000).IsRequired();
            entity.Property(e => e.Price).HasPrecision(10, 2).IsRequired();
            entity.Property(e => e.ProductDesigner).IsRequired();
            entity.Property(e => e.AddedToStoreAt).IsRequired();
            entity.Property(e => e.LastShipmentReceivedAt).IsRequired();
            entity.Property(e => e.SoldSinceAvailable).IsRequired();
            entity.Property(e => e.IsAvailable).IsRequired();
            entity.Property(e => e.Rating).HasDefaultValue(0f);
        });
    }
}