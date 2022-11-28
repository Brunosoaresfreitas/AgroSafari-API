using AgroSafari.Core.Entities;

namespace AgroSafari.Core.Repositories
{
    public interface IServiceProviderRepository
    {
        Task<ServiceProvider> GetByIdAsync(int id);
        Task<List<ServiceProvider>> GetAllAsync();
        Task CreateAsync(ServiceProvider serviceProvider);
        Task DeleteAsync(ServiceProvider serviceProvider);
        Task SaveChangesAsync();
    }
}