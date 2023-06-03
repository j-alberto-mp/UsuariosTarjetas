using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Usuarios.Core.Contratos.Repositorios;
using Usuarios.Core.Entidades;

namespace Usuarios.Repositorios
{
    public class RepositorioTarjetaClientes : RepositorioBase<TarjetaCliente>, IRepositorioTarjetaCliente
    {
        public RepositorioTarjetaClientes(UsuariosContext context) : base(context) { }
    }
}