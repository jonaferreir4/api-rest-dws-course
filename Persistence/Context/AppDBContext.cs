using api_rest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Persistence.Context;
   
public class AppDBContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products {get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

        builder.Entity<Category>().HasData
        (
            new Category { Id = 1, Name = "Fruits and Vegetables" },
            new Category { Id = 2, Name = "Diary" }
        );

        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
        builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
        
    }
            
    }

