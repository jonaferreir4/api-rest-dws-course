using api_rest.Domain.Models;
using api_rest.Resource;

namespace api_rest.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);

        // Task<Category> FindByIdAsync(int id);
        // Task<Category> FindByNameAsync(string name);
        // Task UpdateAsync(Category category);
        // Task RemoveAsync(Category category);
    }
}