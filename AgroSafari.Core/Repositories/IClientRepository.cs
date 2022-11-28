﻿using AgroSafari.Core.Entities;

namespace AgroSafari.Core.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(int id);
        Task<List<Client>> GetAllAsync();
        Task CreateAsync(Client client);
        Task DeleteAsync(Client client);
        Task SaveChangesAsync();
    }
}
