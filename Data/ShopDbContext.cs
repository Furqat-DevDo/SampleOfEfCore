using EfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Data;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {
        
    }

    public DbSet<Stuff> Stuffs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CategoryImage> CategoryImages { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
                base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost; Port=5435; Username=furqat; Password = furqat1234@; Database = MyFirstDB;");
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.LogTo(s =>Console.WriteLine(s));

        }
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

        modelBuilder.Entity<Stuff>().Property(s => s.FullName).HasMaxLength(100);
        modelBuilder.Entity<Category>().Property(s => s.Name).HasMaxLength(100);
        modelBuilder.Entity<Shop>().Property(s => s.Name).HasMaxLength(50);
        modelBuilder.Entity<Product>()
            .Property(s => s.Name)
            .IsRequired()
            .HasPrecision(15, 5) 
            .HasColumnName("product_price");


        modelBuilder.Entity<ProductImage>()
            .Property(x => x.Src)
            .HasColumnType("bytea")
            .HasMaxLength(255)
            .IsUnicode(false);
        modelBuilder.Entity<ProductImage>()
            .ToTable("Products")
            .HasQueryFilter(x => x.IsDeleted != true)
            .HasQueryFilter(x => x.ProductId >= 20000);
        modelBuilder.Entity<Category>()
            .HasQueryFilter(x => x.IsDeleted != true)
            .HasIndex(x => x.UpperId != null);


    }
}
