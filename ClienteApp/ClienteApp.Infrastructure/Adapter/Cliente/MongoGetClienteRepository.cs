using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Cliente.Adapter;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace ClienteApp.Infrastructure.Adapter.Cliente
{
    public class MongoGetClienteRepository : IMongoGetClienteRepository
    {
        private readonly IMongoCollection<Clientes> _clientesCollection;

        public MongoGetClienteRepository(IMongoDatabase mongoDatabase)
        {
            _clientesCollection = mongoDatabase.GetCollection<Clientes>("Clientes");
        }

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return await _clientesCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Clientes> GetByIdAsync(int id)
        {
            return await _clientesCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
