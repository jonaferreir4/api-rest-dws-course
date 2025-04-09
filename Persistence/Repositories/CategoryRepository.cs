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
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }