
using api_rest.Communication;
using api_rest.Domain.Models;

namespace api_rest.Domain.Services;
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<SaveSupplierResponse> SaveAsync(Supplier supplier);
        Task<SaveSupplierResponse> UpdateAsync(int id, Supplier newSupplier);
        Task<SaveSupplierResponse> DeleteAsync(int id);
        Task<SaveSupplierResponse> GetByIdAsync(int id);
    }