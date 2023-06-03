using AutoMapper;
using Microsoft.Extensions.Logging;
using Usuarios.Core.Contratos.Factories;
using Usuarios.Core.Contratos.Servicios;

namespace Usuarios.Servicios
{
    public class ServiceFactory : IServiceFactory
    {
        private IServicioCliente servicioCliente;
        private IServicioTarjetaCliente servicioTarjetaCliente;
        private IUnitOfWork unit;
        private IMapper mapper;

        public ServiceFactory(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public IServicioCliente ServicioCliente
        {
            get
            {
                if (servicioCliente == null)
                {
                    servicioCliente = new ServicioCliente(unit, mapper);
                }

                return servicioCliente;
            }
        }

        public IServicioTarjetaCliente ServicioTarjetaCliente
        {
            get
            {
                if(servicioTarjetaCliente == null)
                {
                    servicioTarjetaCliente = new ServicioTarjetaCliente(unit, mapper);
                }

                return servicioTarjetaCliente;
            }
        }
    }
}