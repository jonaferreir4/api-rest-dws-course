using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Persistence.Repositories;
    public class CategoryRepository: BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context): base(context)
        {
            _context.Database.EnsureCreated();
        }

    public async Task AddAsync(Category category)
    {
        await _context.AddAsync(category);
    }

    public async Task<Category?> FindByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

    public Task RemoveAsync(Category category)
    {
        _context.Categories.Remove(category);
        return Task.CompletedTask;
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();

    }
}