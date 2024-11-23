namespace ClienteApp.Application.Cliente.Commands.Interface
{
    public interface IDeleteClienteCommand
    {
        Task<string> ApagarClienteAsync(int id);
    }
}