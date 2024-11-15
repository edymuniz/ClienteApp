using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Domain.Repository.Queries.Cliente
{
    public interface IGetClienteRepository
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes> GetByIdAsync(int id);
    }
}
