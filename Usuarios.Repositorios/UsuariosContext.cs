using Microsoft.EntityFrameworkCore;
using Usuarios.Core.Entidades;

namespace Usuarios.Repositorios
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) { }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<TarjetaCliente> TarjetaClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}