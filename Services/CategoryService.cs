
using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Domain.Services;

namespace api_rest.Services;
public class CategoryService : ICatogoryService
{
    private readonly ICategoryRespository _categoryRespository;

    public CategoryService(ICategoryRespository categoryRespository)
    {
        _categoryRespository = categoryRespository;
    }
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _categoryRespository.ListAsync();
    }
}
