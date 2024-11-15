using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Domain.Repository.Commands.Cliente
{
    public interface IUpdateClienteRepository
    {
        Task<bool> AlterarClienteAsync(Clientes clienteRequest);
    }
}
