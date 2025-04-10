

namespace api_rest.Domain.Repositories;
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
