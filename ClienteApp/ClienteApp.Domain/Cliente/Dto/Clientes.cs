using ClienteApp.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace ClienteApp.Domain.Cliente.Dto
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public Porte Porte { get; set; }
    }
}