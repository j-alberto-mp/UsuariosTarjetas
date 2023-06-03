using Usuarios.Core.Contratos.Servicios;

namespace Usuarios.Core.Contratos.Factories
{
    public interface IServiceFactory
    {
        IServicioCliente ServicioCliente { get; }

        IServicioTarjetaCliente ServicioTarjetaCliente { get; }
    }
}