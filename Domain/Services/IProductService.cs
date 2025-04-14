
using api_rest.Communication;
using api_rest.Domain.Models;

namespace api_rest.Domain.Services;
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<SaveProductResponse> GetByIdAsync(int id);
        Task<SaveProductResponse> SaveAsync(Product product);
        Task<SaveProductResponse> UpdateAsync(int id, Product product);
        Task<SaveProductResponse> DeleteAsync(int id);
    }