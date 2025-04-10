using api_rest.Communication;
using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Domain.Services;

namespace api_rest.Services;
public class CategoryService(
    ICategoryRepository categoryRespository,
    IUnitOfWork unitOfWork
    ): ICategoryService
{
    private readonly ICategoryRepository _categoryRespository = categoryRespository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _categoryRespository.ListAsync();
    }

    public async Task<SaveCategoryResponse> SaveAsync(Category category)
    {   
        try
        {
            await _categoryRespository.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return new SaveCategoryResponse(category);
        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveCategoryResponse($"An error occurred when saving the category: {ex.Message}");
        }

    }
}