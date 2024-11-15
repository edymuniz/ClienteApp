using ClienteApp.Application.Cliente.Queries.Interface;
using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Repository.Queries.Cliente;

namespace ClienteApp.Application.Cliente.Queries.Service
{
    public class GetClienteService : IGetClienteService
    {
        private readonly IGetClienteRepository _getClienteRepository;

        public GetClienteService(IGetClienteRepository getClienteRepository)
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
