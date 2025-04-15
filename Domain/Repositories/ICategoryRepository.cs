using api_rest.Domain.Models;

namespace api_rest.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);

        Task<Category?> FindByIdAsync(int id);
        // Task<Category> FindByNameAsync(string name);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}