using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Core.Contratos.Factories;
using Usuarios.Core.Contratos.Servicios;
using Usuarios.Core.Dtos;
using Usuarios.Core.Entidades;

namespace Usuarios.Servicios
{
    public class ServicioTarjetaCliente : IServicioTarjetaCliente
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public ServicioTarjetaCliente(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public async Task<bool> CrearAsync(TarjetaClienteDto modelo)
        {
            try
            {
                if (modelo != null)
                {
                    var tarjeta = mapper.Map<TarjetaCliente>(modelo);

                    unit.BeginTransaction();
                    await unit.RepositorioTarjetaCliente.CrearAsync(tarjeta);
                    unit.SaveChanges();
                    unit.Commit();

                    return true;
                }
            }
            catch (Exception)
            {
                unit.Rollback();
            }
            return false;
        }
    }
}