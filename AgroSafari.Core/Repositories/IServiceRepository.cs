using AgroSafari.Core.Entities;

namespace AgroSafari.Core.Repositories
{
    public interface IServiceRepository
    {
        Task<Service> GetByIdAsync(int id);
        Task<List<Service>> GetAllAsync();
        Task CreateAsync(Service service);
        Task DeleteAsync(Service service);
        Task SaveChangesAsync();
    }
}
