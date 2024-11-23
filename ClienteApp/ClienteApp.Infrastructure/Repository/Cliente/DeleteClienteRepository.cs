using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Cliente.SQL;
using ClienteApp.Infrastructure.Data;

namespace ClienteApp.Infrastructure.Repository.Cliente
{
    public class DeleteClienteRepository : IDeleteClienteRepository
    {
        private readonly ClienteDbContext _context;

        public DeleteClienteRepository(ClienteDbContext context)
        {
            _context = context;
        }

        public async Task<string> ApagarClienteAsync(Clientes cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return "Cliente excluído com sucesso.";
        }
    }
}