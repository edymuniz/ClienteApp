using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Domain.Repository.Cliente.SQL
{
    public interface ICreateClienteRepository
    {
        Task<Clientes> SalvarClienteAsync(Clientes clienteRequest);
    }
}
