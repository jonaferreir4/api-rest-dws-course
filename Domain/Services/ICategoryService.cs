using api_rest.Communication;
using api_rest.Domain.Models;

namespace api_rest.Domain.Services;

    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
        Task<SaveCategoryResponse> UpdateAsync(int id, Category newCategory);
        Task<SaveCategoryResponse> DeleteAsync(int id);
        Task<SaveCategoryResponse> GetByIdAsync(int id);
    }