using ClienteApp.Domain.Cliente.Dto;
using MongoDB.Driver;

namespace ClienteApp.Domain.Repository.Cliente.Adapter
{
    public interface IMongoUpdateClienteRepository
    {
        Task<ReplaceOneResult> AlterarClienteAsync(Clientes clienteRequest, IClientSessionHandle clientSession);
    }
}
