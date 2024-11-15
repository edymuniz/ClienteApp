using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Commands.Cliente;
using ClienteApp.Infrastructure.Data;
using MongoDB.Driver;

namespace ClienteApp.Infrastructure.Repository.Cliente
{
    public class DeleteClienteRepository : IDeleteClienteRepository
    {
        private readonly ClienteDbContext _context;
        private readonly IMongoCollection<Clientes> _mongoCollection;

        public DeleteClienteRepository(ClienteDbContext context, IMongoDatabase mongoDatabase)
        {
            _context = context;
            _mongoCollection = mongoDatabase.GetCollection<Clientes>("Clientes");
        }

        public async Task<string> ApagarClienteAsync(Clientes cliente)
        {
            try
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                var filter = Builders<Clientes>.Filter.Eq(c => c.Id, cliente.Id);
                await _mongoCollection.DeleteOneAsync(filter);

                return "Cliente excluido com sucesso.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }        
    }
}