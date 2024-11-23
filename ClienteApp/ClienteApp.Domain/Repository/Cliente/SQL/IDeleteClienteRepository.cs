using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Domain.Repository.Cliente.SQL
{
    public interface IDeleteClienteRepository
    {
        Task<string> ApagarClienteAsync(Clientes cliente);
    }
}
