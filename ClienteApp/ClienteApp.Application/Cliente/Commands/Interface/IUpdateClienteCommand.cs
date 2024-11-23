using ClienteApp.Domain.Cliente.Request;

namespace ClienteApp.Application.Cliente.Commands.Interface
{
    public interface IUpdateClienteCommand
    {
        Task<string> AlterarClienteAsync(int id, ClienteRequest clienteRequest);
    }
}
