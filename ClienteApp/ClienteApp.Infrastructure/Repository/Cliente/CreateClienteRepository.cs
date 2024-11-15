using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Commands.Cliente;
using ClienteApp.Infrastructure.Data;
using MongoDB.Driver;

namespace ClienteApp.Infrastructure.Repository.Cliente
{
    public class CreateClienteRepository : ICreateClienteRepository
    {
        private readonly ClienteDbContext _context;
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IDeleteClienteRepository _deleteClienteRepository;

        public CreateClienteRepository(ClienteDbContext context, IMongoDatabase mongoDatabase, IDeleteClienteRepository deleteClienteRepository)
        {
            _context = context;
            _mongoDatabase = mongoDatabase;
            _deleteClienteRepository = deleteClienteRepository;
        }

        public async Task<Clientes> SalvarClienteAsync(Clientes client)
        {
            try
            {
                await _context.Clientes.AddAsync(client);
                await _context.SaveChangesAsync();

                var mongoCollection = _mongoDatabase.GetCollection<Clientes>("Clientes");
                await mongoCollection.InsertOneAsync(client);

                return client;
            }
            catch (Exception ex)
            {
                await _deleteClienteRepository.ApagarClienteAsync(client);
                return null;
            }
        }
    }
}
