using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Core.Dtos;

namespace Usuarios.Core.Contratos.Servicios
{
    public interface IServicioTarjetaCliente
    {
        Task<bool> CrearAsync(TarjetaClienteDto modelo);
    }
}
