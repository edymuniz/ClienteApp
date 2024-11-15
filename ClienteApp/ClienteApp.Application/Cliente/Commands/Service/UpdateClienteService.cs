using AutoMapper;
using ClienteApp.Application.Cliente.Commands.Interface;
using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Cliente.Request;
using ClienteApp.Domain.Repository.Commands.Cliente;
using ClienteApp.Domain.Repository.Queries.Cliente;

namespace ClienteApp.Application.Cliente.Commands.Service
{
    public class UpdateClienteService : IUpdateClienteService
    {
        private readonly IUpdateClienteRepository _updateClienteRepository;
        private readonly IMapper _mapper;
        private readonly IGetClienteRepository _getClienteRepository;
        

        public UpdateClienteService(IUpdateClienteRepository updateClienteRepository, 
                                    IMapper mapper, 
                                    IGetClienteRepository getClienteRepository)
        {
            _updateClienteRepository = updateClienteRepository;
            _mapper = mapper;
            _getClienteRepository = getClienteRepository;            
        }

        public async Task<bool> AlterarClienteAsync(int id, ClienteRequest clienteRequest)
        {
            _ = await _getClienteRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Cliente com ID {id} não encontrado no banco de dados.");
            var cliente = _mapper.Map<Clientes>(clienteRequest);
            cliente.Id = id;

            return await _updateClienteRepository.AlterarClienteAsync(cliente);
        }
    }
}