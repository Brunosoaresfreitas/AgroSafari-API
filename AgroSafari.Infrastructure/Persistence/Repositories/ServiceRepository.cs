using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgroSafari.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AgroSafariDbContext _dbContext;

        public ServiceRepository(AgroSafariDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Service service)
        {
            await _dbContext.Services.AddAsync(service);
        }

        public async Task DeleteAsync(Service service)
        {
            _dbContext.Services.Remove(service);
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _dbContext.Services.ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _dbContext.Services.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
