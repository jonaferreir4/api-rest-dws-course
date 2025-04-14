
using api_rest.Communication;
using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Domain.Services;

namespace api_rest.Services;
public class SupplierService(
    ISupplierRepository supplierRespository,
    IUnitOfWork unitOfWork 
) : ISupplierService
{
    private readonly ISupplierRepository _supplierRespository = supplierRespository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<SaveSupplierResponse> DeleteAsync(int id)
    {
        var supplier =  await _supplierRespository.FindByIdAsync(id);
        if (supplier == null)
            return new SaveSupplierResponse("supplier not found.");
        try {

            await _supplierRespository.RemoveAsync(supplier);
            await _unitOfWork.CompleteAsync();

            return new SaveSupplierResponse(supplier);
        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveSupplierResponse($"An error occurred when deleting the supplier: {ex.Message}");
        }
    }

    public Task<IEnumerable<Supplier>> GetAllAsync()
    {
        return _supplierRespository.ListAsync();
    }

    public async Task<SaveSupplierResponse> GetByIdAsync(int id)
    {
        var supplier =  await _supplierRespository.FindByIdAsync(id);
        if (supplier == null)
            return new SaveSupplierResponse("supplier not found.");
        try {
            return new SaveSupplierResponse(supplier);
        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveSupplierResponse($"An error occurred when getting the supplier: {ex.Message}");
        }
    }

    public async Task<SaveSupplierResponse> SaveAsync(Supplier supplier)
    {
        try
        {
            await _supplierRespository.AddAsync(supplier);
            await _unitOfWork.CompleteAsync();

            return new SaveSupplierResponse(supplier);
        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveSupplierResponse($"An error occurred when saving the supplier: {ex.Message}");
        }
    }

    public async Task<SaveSupplierResponse> UpdateAsync(int id, Supplier newSupplier)
    {
        try {
            var supplier = await _supplierRespository.FindByIdAsync(id);
            if (supplier == null)
                return new SaveSupplierResponse("supplier not found.");
            supplier.Name = newSupplier.Name;
            supplier.Address = newSupplier.Address;
            supplier.PhoneNumber = newSupplier.PhoneNumber;
            supplier.ContactEmail = newSupplier.ContactEmail;
            

            await _supplierRespository.UpdateAsync(supplier);
            await _unitOfWork.CompleteAsync();

            return new SaveSupplierResponse(supplier);
        } catch(Exception ex)
        {
            // Do some logging stuff
            return new SaveSupplierResponse($"An error occurred when updating the supplier: {ex.Message}");
        }
    }
}