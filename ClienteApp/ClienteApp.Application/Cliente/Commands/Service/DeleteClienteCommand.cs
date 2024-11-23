using ClienteApp.Application.Cliente.Commands.Interface;
using ClienteApp.Domain.Repository.Cliente.Adapter;
using ClienteApp.Domain.Repository.Cliente.SQL;
using ClienteApp.Infrastructure.Data;
using MongoDB.Driver;

namespace ClienteApp.Application.Cliente.Commands.Service
{
    public class DeleteClienteCommand : IDeleteClienteCommand
    {
        private readonly IDeleteClienteRepository _deleteClienteRepository;
        private readonly IMongoDeleteClienteRepository _mongoDeleteClienteRepository;
        private readonly IMongoGetClienteRepository _getClienteRepository;
        private readonly ClienteDbContext _sqlContext;
        private readonly IMongoDatabase _mongoDatabase;

        public DeleteClienteCommand(IDeleteClienteRepository deleteClienteRepository,
                                    IMongoDeleteClienteRepository mongoDeleteClienteRepository,
                                    IMongoGetClienteRepository getClienteRepository,
                                    ClienteDbContext clienteDbContext,
                                    IMongoDatabase mongoDatabase)
        {
            _deleteClienteRepository = deleteClienteRepository;
            _mongoDeleteClienteRepository = mongoDeleteClienteRepository;
            _getClienteRepository = getClienteRepository;
            _sqlContext = clienteDbContext;
            _mongoDatabase = mongoDatabase;
        }

        public async Task<string> ApagarClienteAsync(int id)
        {
            var cliente = await _getClienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return null;
            }

            using var sqlTransaction = await _sqlContext.Database.BeginTransactionAsync();
            using var mongoSession = await _mongoDatabase.Client.StartSessionAsync();

            try
            {
                mongoSession.StartTransaction();

                var resultDelete = await _deleteClienteRepository.ApagarClienteAsync(cliente);
                await _mongoDeleteClienteRepository.ApagarClienteAsync(cliente, mongoSession);

                await sqlTransaction.CommitAsync();
                await mongoSession.CommitTransactionAsync();

                return resultDelete;
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
