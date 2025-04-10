using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Mapping;
using api_rest.Persistence.Context;
using api_rest.Resource;
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

    public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

    public Task RemoveAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }
}