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
    public class UpdateClienteCommand : IUpdateClienteCommand
    {
        private readonly IUpdateClienteRepository _updateClienteRepository;
        private readonly IMongoUpdateClienteRepository _mongoUpdateClienteRepository; 
        private readonly IMapper _mapper;
        private readonly IMongoGetClienteRepository _getClienteRepository;
        private readonly ClienteDbContext _sqlContext;
        private readonly IMongoDatabase _mongoDatabase;

        public UpdateClienteCommand(IUpdateClienteRepository updateClienteRepository,
                                    IMongoUpdateClienteRepository mongoUpdateClienteRepository,
                                    IMapper mapper,
                                    IMongoGetClienteRepository getClienteRepository,
                                    ClienteDbContext clienteDbContext,
                                    IMongoDatabase mongoDatabase)
        {
            _updateClienteRepository = updateClienteRepository;
            _mongoUpdateClienteRepository = mongoUpdateClienteRepository;
            _mapper = mapper;
            _getClienteRepository = getClienteRepository;
            _mongoDatabase = mongoDatabase;
            _sqlContext = clienteDbContext;
        }

        public async Task<string> AlterarClienteAsync(int id, ClienteRequest clienteRequest)
        {
            var result = await _getClienteRepository.GetByIdAsync(id);
            if (result == null) { return null; }

            using var sqlTransaction = await _sqlContext.Database.BeginTransactionAsync();
            using var mongoSession = await _mongoDatabase.Client.StartSessionAsync();
            var cliente = _mapper.Map<Clientes>(clienteRequest);
            cliente.Id = id;

            try
            {
                mongoSession.StartTransaction();

                var resultUpdate = await _updateClienteRepository.AlterarClienteAsync(cliente);
                var resultMongo = await _mongoUpdateClienteRepository.AlterarClienteAsync(cliente, mongoSession);

                if (resultMongo.ModifiedCount == 0 && !resultMongo.UpsertedId.IsBsonNull)
                {
                    await mongoSession.AbortTransactionAsync();
                    await sqlTransaction.RollbackAsync();
                    return "Erro ao atualizar o cliente nos bancos de dados.";
                }

                await sqlTransaction.CommitAsync();
                await mongoSession.CommitTransactionAsync();

                return resultUpdate;
            }
            catch (Exception ex)
            {
                if (mongoSession.IsInTransaction)
                    await mongoSession.AbortTransactionAsync();

                await sqlTransaction.RollbackAsync();
                return "Erro ao excluir cliente: " + ex;
            }
        }
    }
}