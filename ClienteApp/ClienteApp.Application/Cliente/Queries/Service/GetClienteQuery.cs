using ClienteApp.Application.Cliente.Queries.Interface;
using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Cliente.Adapter;

namespace ClienteApp.Application.Cliente.Queries.Service
{
    public class GetClienteQuery : IGetClienteQuery
    {
        private readonly IMongoGetClienteRepository _getClienteRepository;

        public GetClienteQuery(IMongoGetClienteRepository getClienteRepository)
        {
            _getClienteRepository = getClienteRepository;
        }

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return await _getClienteRepository.GetAllAsync();
        }

        public async Task<Clientes> GetByIdAsync(int id)
        {
            return await _getClienteRepository.GetByIdAsync(id);
        }
    }
}
