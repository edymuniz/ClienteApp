using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Commands.Cliente;
using ClienteApp.Infrastructure.Data;
using MongoDB.Driver;

namespace ClienteApp.Infrastructure.Repository.Cliente
{
    public class UpdateClienteRepository : IUpdateClienteRepository
    {
        private readonly ClienteDbContext _context;
        private readonly IMongoCollection<Clientes> _mongoCollection;

        public UpdateClienteRepository(ClienteDbContext context, IMongoDatabase mongoDatabase)
        {
            _context = context;
            _mongoCollection = mongoDatabase.GetCollection<Clientes>("Clientes");
        }

        public async Task<bool> AlterarClienteAsync(Clientes cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                var filter = Builders<Clientes>.Filter.Eq(c => c.Id, cliente.Id);
                var updateResult = await _mongoCollection.ReplaceOneAsync(filter, cliente, new ReplaceOptions { IsUpsert = true });

                if (updateResult.ModifiedCount == 0)
                {
                    throw new Exception("Erro ao atualizar o cliente nos bancos de dados.");
                }

                return true;
            }catch (Exception ex) { return false; }
        }
    }
}