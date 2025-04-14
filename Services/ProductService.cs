
using api_rest.Communication;
using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Domain.Services;

namespace api_rest.Services;
public class ProductService(
    IProductRepository productRespository,
    IUnitOfWork unitOfWork
) : IProductService
{

    private readonly IProductRepository _productRespository = productRespository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<SaveProductResponse> SaveAsync(Product product)
    {
        try
        {
            await _productRespository.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return new SaveProductResponse(product);
        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveProductResponse($"An error occurred when saving the product: {ex.Message}");
        }
    }
    

    public Task<SaveProductResponse> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> ListAsync()
    {
        return _productRespository.ListAsync();
    }

    public Task<SaveProductResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }


    public Task<SaveProductResponse> UpdateAsync(int id, Product product)
    {
        throw new NotImplementedException();
    }
}
