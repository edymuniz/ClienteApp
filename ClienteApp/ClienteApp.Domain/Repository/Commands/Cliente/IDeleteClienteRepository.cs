using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Domain.Repository.Commands.Cliente
{
    public interface IDeleteClienteRepository
    {
        Task<string> ApagarClienteAsync(Clientes cliente);
    }
}
