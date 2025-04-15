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

    public async Task<SaveCategoryResponse> DeleteAsync(int id)
    {
        var category =  await _categoryRespository.FindByIdAsync(id);
        if (category == null)
            return new SaveCategoryResponse("Category not found.");
        try {

            await _categoryRespository.DeleteAsync(category);
            await _unitOfWork.CompleteAsync();

            return new SaveCategoryResponse(category);
        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveCategoryResponse($"An error occurred when deleting the category: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _categoryRespository.ListAsync();
    }

    public async Task<SaveCategoryResponse> GetByIdAsync(int id)
    {
        var category =  await _categoryRespository.FindByIdAsync(id);
        if (category == null)
            return new SaveCategoryResponse("Category not found.");
        try {
            return new SaveCategoryResponse(category);
        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveCategoryResponse($"An error occurred when getting the category: {ex.Message}");
        }
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

    public async Task<SaveCategoryResponse> UpdateAsync(int id, Category newCategory)
    {
        try {

            var category = await _categoryRespository.FindByIdAsync(id);
            if (category == null)
                return new SaveCategoryResponse("Category not found.");

            category.Name = newCategory.Name;

            await _categoryRespository.UpdateAsync(category);
            await _unitOfWork.CompleteAsync();

            return new SaveCategoryResponse(category);

        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveCategoryResponse($"An error occurred when updating the category: {ex.Message}");
        }
    }
}