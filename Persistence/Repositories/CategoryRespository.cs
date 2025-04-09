
using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Persistence.Repositories;
    public class CategoryRespository: BaseRepository, ICategoryRespository
    {
        public CategoryRespository(AppDBContext context): base(context)
        {
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }