using api_rest.Domain.Models;

namespace api_rest.Domain.Repositories;
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);        
    }
