using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Cliente.SQL;
using ClienteApp.Infrastructure.Data;

namespace ClienteApp.Infrastructure.Repository.Cliente
{
    public class UpdateClienteRepository : IUpdateClienteRepository
    {
        private readonly ClienteDbContext _context;

        public UpdateClienteRepository(ClienteDbContext context)
        {
            _context = context;
        }

        public async Task<string> AlterarClienteAsync(Clientes cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return "Cliente atualizado com sucesso.";            
        }
    }
}