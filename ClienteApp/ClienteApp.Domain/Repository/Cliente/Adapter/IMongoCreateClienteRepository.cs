using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Domain.Repository.Cliente.Adapter
{
    public interface IMongoCreateClienteRepository
    {
        Task SalvarClienteAsync(Clientes clienteRequest);
    }
}
