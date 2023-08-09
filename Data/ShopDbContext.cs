﻿using EfCore.Entities;
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
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Username=Furqat; Password = furqat1234@; Database = MyFirstDB;");
        optionsBuilder.EnableSensitiveDataLogging(true);
        optionsBuilder.LogTo(s =>Console.WriteLine(s));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Storage>(s =>
        {
            s.Property(t => t.ProductIds).HasColumnType("jsonb");
        });
    }
}
