using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Persistence.Repositories;
public class SupplierRepository : BaseRepository, ISupplierRepository
{
    public SupplierRepository(AppDbContext context) : base(context)
    {
        _context.Database.EnsureCreated();
    }

    public async Task AddAsync(Supplier supplier)
    {
        await _context.AddAsync(supplier);
    }


    public async Task<IEnumerable<Supplier>> ListAsync()
    {
        return await _context.Suppliers.ToListAsync();
    }

    public async Task<Supplier?> FindByIdAsync(int id)
    {
        return await _context.Suppliers.FindAsync(id);
    }

    public async Task RemoveAsync(Supplier supplier)
    {
        _context.Remove(supplier);
        await Task.CompletedTask;

    }

    public Task UpdateAsync(Supplier supplier)
    {
        _context.Suppliers.Update(supplier);
        return _context.SaveChangesAsync();
    }
}