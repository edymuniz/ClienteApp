namespace ClienteApp.Application.Cliente.Commands.Interface
{
    public interface IDeleteClienteService
    {
        Task<string> ApagarClienteAsync(int id);
    }
}