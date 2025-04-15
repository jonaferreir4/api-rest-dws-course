
using api_rest.Communication;
using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Domain.Services;
using api_rest.Persistence.Repositories;

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
    

    public async Task<SaveProductResponse> FindByIdAsync(int id)
    {
        var product =  await _productRespository.FindByIdAsync(id);
        if (product == null)
            return new SaveProductResponse("Product not found");
        return new SaveProductResponse(product);
    }

    public Task<IEnumerable<Product>> ListAsync()
    {
        return _productRespository.ListAsync();
    }

    public async Task<SaveProductResponse> DeleteAsync(int id)
    {
        var product =  await _productRespository.FindByIdAsync(id);
        if (product == null)
            return new SaveProductResponse("product not found.");
        try {

            await _productRespository.DeleteAsync(product);
            await _unitOfWork.CompleteAsync();

            return new SaveProductResponse(product);
        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveProductResponse($"An error occurred when deleting the product: {ex.Message}");
        }
    }


    public async Task<SaveProductResponse> UpdateAsync(int id, Product newProduct)
    {
         try {

            var product = await _productRespository.FindByIdAsync(id);
            if (product == null)
                return new SaveProductResponse("product not found.");

            product.Name = newProduct.Name;
            product.QuantityInPackage = newProduct.QuantityInPackage;
            product.UnitOfMeasurement = newProduct.UnitOfMeasurement;

            await _productRespository.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();

            return new SaveProductResponse(product);

        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveProductResponse($"An error occurred when updating the category: {ex.Message}");
        }
    }

}
