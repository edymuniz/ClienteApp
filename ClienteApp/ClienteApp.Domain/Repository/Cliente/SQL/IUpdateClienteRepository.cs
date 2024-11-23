using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Domain.Repository.Cliente.SQL
{
    public interface IUpdateClienteRepository
    {
        Task<string> AlterarClienteAsync(Clientes clienteRequest);
    }
}
