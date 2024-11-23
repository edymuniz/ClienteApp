using ClienteApp.Domain.Cliente.Dto;

namespace ClienteApp.Domain.Repository.Cliente.Adapter
{
    public interface IMongoGetClienteRepository
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes> GetByIdAsync(int id);
    }
}
