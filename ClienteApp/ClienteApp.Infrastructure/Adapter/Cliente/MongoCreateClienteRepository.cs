using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Cliente.Adapter;
using MongoDB.Driver;

namespace ClienteApp.Infrastructure.Adapter.Cliente
{
    public class MongoCreateClienteRepository : IMongoCreateClienteRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoCreateClienteRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task SalvarClienteAsync(Clientes cliente)
        {
            var collection = _mongoDatabase.GetCollection<Clientes>("Clientes");
            await collection.InsertOneAsync(cliente);
        }
    }
}