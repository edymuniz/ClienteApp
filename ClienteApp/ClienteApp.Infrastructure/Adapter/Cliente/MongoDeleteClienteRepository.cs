using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Cliente.Adapter;
using MongoDB.Driver;

namespace ClienteApp.Infrastructure.Adapter.Cliente
{
    public class MongoDeleteClienteRepository : IMongoDeleteClienteRepository
    {
        private readonly IMongoCollection<Clientes> _mongoCollection;

        public MongoDeleteClienteRepository(IMongoDatabase mongoDatabase)
        {
            _mongoCollection = mongoDatabase.GetCollection<Clientes>("Clientes");
        }

        public async Task ApagarClienteAsync(Clientes cliente, IClientSessionHandle clientSession)
        {
            var filter = Builders<Clientes>.Filter.Eq(c => c.Id, cliente.Id);
            await _mongoCollection.DeleteOneAsync(clientSession, filter);
        }
    }
}
