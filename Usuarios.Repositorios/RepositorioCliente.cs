using Usuarios.Core.Contratos.Repositorios;
using Usuarios.Core.Entidades;

namespace Usuarios.Repositorios
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(UsuariosContext context) : base(context) { }
    }
}