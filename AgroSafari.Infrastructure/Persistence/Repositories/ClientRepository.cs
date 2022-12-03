using AgroSafari.Core.Entities;
using AgroSafari.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgroSafari.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AgroSafariDbContext _dbContext;

        public ClientRepository(AgroSafariDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _dbContext.Clients.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Client client)
        {
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Client client)
        {
            _dbContext.Clients.Remove(client);
        }

        public async Task<Client> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext
                .Clients.
                SingleOrDefaultAsync(c => c.Email == email && c.Password == passwordHash);
        }
    }
}
