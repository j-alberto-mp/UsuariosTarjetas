using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Core.Entidades;

namespace Usuarios.Core.Contratos.Repositorios
{
    public interface IRepositorioTarjetaCliente
    {
        Task CrearAsync(TarjetaCliente modelo);
    }
}
