using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Domain.Repository.Commands.Cliente
{
    public interface ICreateClienteRepository
    {
        Task<Clientes> SalvarClienteAsync(Clientes clienteRequest);
    }
}
