using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Persistence.Repositories;
    public class ProductRepository: BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context): base(context)
        {
            _context.Database.EnsureCreated();
        }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public Task DeleteAsync(Product product)
    {
         _context.Products.Remove(product);
        return Task.CompletedTask;
    }

    public async Task<Product?> FindByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task UpdateAsync(Product product)
    {
         _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}