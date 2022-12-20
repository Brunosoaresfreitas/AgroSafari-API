using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgroSafari.Infrastructure.Persistence.Repositories
{
    public class ServiceProviderRepository : IServiceProviderRepository
    {
        private readonly AgroSafariDbContext _dbContext;

        public ServiceProviderRepository(AgroSafariDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(ServiceProvider serviceProvider)
        {
            await _dbContext.ServiceProviders.AddAsync(serviceProvider);
        }

        public async Task DeleteAsync(ServiceProvider serviceProvider)
        {
            _dbContext.ServiceProviders.Remove(serviceProvider);
        }

        public async Task<List<ServiceProvider>> GetAllAsync()
        {
            return await _dbContext.ServiceProviders.ToListAsync();
        }

        public async Task<ServiceProvider> GetByIdAsync(int id)
        {
            return await _dbContext.ServiceProviders.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ServiceProvider> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext
                .ServiceProviders
                .SingleOrDefaultAsync(s => s.Email == email && s.Password == passwordHash);
        }

        public async Task SaveChangesAsync()
        {
             await _dbContext.SaveChangesAsync();
        }
    }
}
