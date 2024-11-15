using ClienteApp.Domain.Enum;

namespace ClienteApp.Domain.Cliente.Request
{
    public class ClienteRequest
    {
        public string NomeEmpresa { get; set; }
        public Porte Porte { get; set; }
    }
}
