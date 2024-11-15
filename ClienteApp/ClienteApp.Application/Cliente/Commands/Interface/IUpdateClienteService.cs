using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Cliente.Request;

namespace ClienteApp.Application.Cliente.Commands.Interface
{
    public interface IUpdateClienteService
    {
        Task<bool> AlterarClienteAsync(int id, ClienteRequest clienteRequest);
    }
}
