using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Cliente.SQL;
using ClienteApp.Infrastructure.Data;

namespace ClienteApp.Infrastructure.Repository.Cliente
{
    public class CreateClienteRepository : ICreateClienteRepository
    {
        private readonly ClienteDbContext _context;

        public CreateClienteRepository(ClienteDbContext context)
        {
            _context = context;
        }

        public async Task<Clientes> SalvarClienteAsync(Clientes client)
        {
            await _context.Clientes.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}