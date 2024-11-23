using ClienteApp.Domain.Cliente.Dto;
using MongoDB.Driver;

namespace ClienteApp.Domain.Repository.Cliente.Adapter
{
    public interface IMongoDeleteClienteRepository
    {
        Task ApagarClienteAsync(Clientes cliente, IClientSessionHandle clientSession);
    }
}
