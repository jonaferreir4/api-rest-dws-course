using api_rest.Domain.Models;

namespace api_rest.Domain.Repositories;
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> ListAsync();
        Task<Supplier?> FindByIdAsync(int id);
        Task AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(Supplier supplier);
    }
