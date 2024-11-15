using AutoMapper;
using ClienteApp.Application.Cliente.Commands.Interface;
using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Cliente.Request;
using ClienteApp.Domain.Repository.Commands.Cliente;

namespace ClienteApp.Application.Cliente.Commands.Service
{
    public class CreateClienteService : ICreateClienteService
    {
        private readonly ICreateClienteRepository _createClienteRepository;
        private readonly IMapper _mapper;
        

        public CreateClienteService(ICreateClienteRepository createClienteRepository, IMapper mapper)
        {
            _createClienteRepository = createClienteRepository;
            _mapper = mapper;
        }

        public async Task<Clientes> SalvarClienteAsync(ClienteRequest clienteRequest)
        {
            var cliente = _mapper.Map<Clientes>(clienteRequest);
            var result = await _createClienteRepository.SalvarClienteAsync(cliente);
            if (result == null)
                return null;

            return result;
        }
    }
}
