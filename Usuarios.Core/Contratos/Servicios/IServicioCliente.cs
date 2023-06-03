using System.Collections.Generic;
using System.Threading.Tasks;
using Usuarios.Core.Dtos;
using Usuarios.Core.Utilidades;

namespace Usuarios.Core.Contratos.Servicios
{
    public interface IServicioCliente
    {
        Task<Respuesta<bool>> CrearAsync(ClienteDto modelo);

        Task<Respuesta<bool>> ActualizarAsync(ClienteDto modelo);

        Task<Respuesta<bool>> EliminarAsync(int id);

        Task<Respuesta<ClienteDto>> ObtenerPorIdAsync(int id);

        Task<Respuesta<List<ClienteDto>>> ObtenerListaAsync();

        Task<Respuesta<List<ClienteDto>>> ObtenerUsuariosSinTarjetaAsync();
    }
}