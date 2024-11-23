using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Cliente.Adapter;
using MongoDB.Driver;

namespace ClienteApp.Infrastructure.Adapter.Cliente
{
    public class MongoUpdateClienteRepository : IMongoUpdateClienteRepository
    {
        private readonly IMongoCollection<Clientes> _mongoCollection;

        public MongoUpdateClienteRepository(IMongoDatabase mongoDatabase)
        {
            _mongoCollection = mongoDatabase.GetCollection<Clientes>("Clientes");
        }

        public async Task<ReplaceOneResult> AlterarClienteAsync(Clientes cliente, IClientSessionHandle clientSession)
        {
            var filter = Builders<Clientes>.Filter.Eq(c => c.Id, cliente.Id);
            return await _mongoCollection.ReplaceOneAsync(
                clientSession,
                filter,
                cliente,
                new ReplaceOptions { IsUpsert = true });
        }
    }
}
