using api_rest.Communication;
using api_rest.Domain.Models;

namespace api_rest.Domain.Services;

    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
    }