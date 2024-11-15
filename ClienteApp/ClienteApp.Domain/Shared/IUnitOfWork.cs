namespace ClienteApp.Domain.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
