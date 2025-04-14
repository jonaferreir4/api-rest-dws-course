using api_rest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Persistence.Context;
   
public class AppDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products {get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

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

        builder.Entity<Supplier>().ToTable("Suppliers");
        builder.Entity<Supplier>().HasKey(s => s.Id);
        builder.Entity<Supplier>().Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Entity<Supplier>().Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Supplier>().Property(s => s.ContactEmail).IsRequired().HasMaxLength(15);
        builder.Entity<Supplier>().Property(s => s.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.Entity<Supplier>().Property(s => s.Address).IsRequired().HasMaxLength(100);
        builder.Entity<Supplier>().HasMany(s => s.Products).WithOne(p => p.Supplier).HasForeignKey(p => p.SupplierId);

         builder.Entity<Supplier>().HasData
        (
            new Supplier { Id = 1,Name = "Fulalo", Address = "Rua Fulando de Tal, 3434, Centro", ContactEmail = "fulano@gmail.com", PhoneNumber = "8888888888" },
            new Supplier { Id = 2,Name = "Ciclano", Address = "Rua Ciclano de Tal, 3434, Centro", ContactEmail = "ciclano@gmail.com", PhoneNumber = "8888888888" }
        );
        
    }
            
    }

