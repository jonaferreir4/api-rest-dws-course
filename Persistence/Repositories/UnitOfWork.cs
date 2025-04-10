using api_rest.Domain.Repositories;
using api_rest.Persistence.Context;

namespace api_rest.Persistence.Repositories;
    public class UnitOfWork(AppDbContext context): IUnitOfWork
    {
        private readonly AppDbContext _context = context;

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}