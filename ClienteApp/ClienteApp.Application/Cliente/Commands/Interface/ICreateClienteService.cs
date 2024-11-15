using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Cliente.Request;

namespace ClienteApp.Application.Cliente.Commands.Interface
{
    public interface ICreateClienteService
    {
        Task<Clientes> SalvarClienteAsync(ClienteRequest clienteRequest);
    }
}
