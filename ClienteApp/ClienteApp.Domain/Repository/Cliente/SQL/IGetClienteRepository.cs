using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Domain.Repository.Cliente.SQL
{
    public interface IGetClienteRepository
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes> GetByIdAsync(int id);
    }
}
