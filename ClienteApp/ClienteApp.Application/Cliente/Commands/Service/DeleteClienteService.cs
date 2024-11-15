using AutoMapper;
using ClienteApp.Application.Cliente.Commands.Interface;
using ClienteApp.Domain.Repository.Commands.Cliente;
using ClienteApp.Domain.Repository.Queries.Cliente;

namespace ClienteApp.Application.Cliente.Commands.Service
{
    public class DeleteClienteService : IDeleteClienteService
    {
        private readonly IDeleteClienteRepository _deleteClienteRepository;
        private readonly IGetClienteRepository _getClienteRepository;

        public DeleteClienteService(IDeleteClienteRepository deleteClienteRepository, IGetClienteRepository getClienteRepository)
        {
            _deleteClienteRepository = deleteClienteRepository;
            _getClienteRepository = getClienteRepository;
        }

        public async Task<string> ApagarClienteAsync(int id)
        {
            var cliente = await _getClienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado no banco de dados.");
            }

            return await _deleteClienteRepository.ApagarClienteAsync(cliente);
        }
    }
}
