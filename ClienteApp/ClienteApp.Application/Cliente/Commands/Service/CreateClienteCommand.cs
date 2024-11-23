using AutoMapper;
using ClienteApp.Application.Cliente.Commands.Interface;
using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Cliente.Request;
using ClienteApp.Domain.Repository.Cliente.Adapter;
using ClienteApp.Domain.Repository.Cliente.SQL;
using ClienteApp.Infrastructure.Data;
using MongoDB.Driver;

namespace ClienteApp.Application.Cliente.Commands.Service
{
    public class CreateClienteCommand : ICreateClienteCommand
    {
        private readonly ICreateClienteRepository _createClienteRepository;
        private readonly IMongoCreateClienteRepository _mongoCreateClienteRepository ;
        private readonly IMapper _mapper;
        private readonly ClienteDbContext _sqlContext;
        private readonly IMongoDatabase _mongoDatabase;

        public CreateClienteCommand(ICreateClienteRepository createClienteRepository, 
                                    IMapper mapper, 
                                    IMongoCreateClienteRepository mongoCreateClienteRepository,
                                    ClienteDbContext clienteDbContext,
                                    IMongoDatabase mongoDatabase)
        {
            _createClienteRepository = createClienteRepository;
            _mapper = mapper;
            _mongoCreateClienteRepository = mongoCreateClienteRepository;
            _mongoDatabase = mongoDatabase;
            _sqlContext = clienteDbContext;
        }

        public async Task<Clientes> SalvarClienteAsync(ClienteRequest clienteRequest)
        {
            var cliente = _mapper.Map<Clientes>(clienteRequest);

            using var sqlTransaction = await _sqlContext.Database.BeginTransactionAsync();
            using var mongoSession = await _mongoDatabase.Client.StartSessionAsync();

            try
            {
                mongoSession.StartTransaction();

                var clienteSalvo = await _createClienteRepository.SalvarClienteAsync(cliente);
                await _mongoCreateClienteRepository.SalvarClienteAsync(cliente);

                await sqlTransaction.CommitAsync();
                await mongoSession.CommitTransactionAsync();

                return clienteSalvo;
            }
            catch (Exception ex)
            {
                if (mongoSession.IsInTransaction)
                    await mongoSession.AbortTransactionAsync();

                await sqlTransaction.RollbackAsync();
                throw new Exception("Erro ao salvar cliente", ex);
            }
        }
    }
}