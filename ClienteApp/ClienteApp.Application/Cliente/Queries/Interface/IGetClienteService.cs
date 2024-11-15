using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Application.Cliente.Queries.Interface
{
    public interface IGetClienteService
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes> GetByIdAsync(int id);
    }
}
