using ClienteApp.Domain.Cliente.Dto;
using Microsoft.EntityFrameworkCore;

namespace ClienteApp.Infrastructure.Data
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Clientes>().HasKey(e => e.Id);


        }
    }
}
