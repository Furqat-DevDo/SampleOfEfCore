using EfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Data;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {
        
    }




    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CategoryImage> CategoryImages { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging(true);
        optionsBuilder.LogTo(s =>Console.WriteLine(s));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Storage>(s =>
        {
            s.Property(t => t.ProductIds).HasColumnType("jsonb");
            s.HasQueryFilter(s=> s.IsDeleted != true);
        });

        modelBuilder.Entity<Shop>(sh =>
        {
            sh.HasQueryFilter(s=>s.IsDeleted != true);
        });

        modelBuilder.Entity<Company>(company => 
        {
            company.HasQueryFilter(c=>!c.IsDeleted);
        });

        modelBuilder.Entity<Staff>(stuff =>
        {
            stuff.HasQueryFilter(c => !c.IsDeleted);
        });
    }
}
