using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Core.Contratos.Factories;
using Usuarios.Core.Contratos.Servicios;
using Usuarios.Core.Dtos;
using Usuarios.Core.Entidades;
using Usuarios.Core.Utilidades;

namespace Usuarios.Servicios
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public ServicioCliente(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public async Task<Respuesta<bool>> ActualizarAsync(ClienteDto modelo)
        {
            try
            {
                var busqueda = await unit.RepositorioCliente.ObtenerAsync(q => q.ClienteID == modelo.ClienteID);

                if (busqueda != null)
                {
                    busqueda.Nombre = !string.IsNullOrEmpty(modelo.Nombre) ? modelo.Nombre : busqueda.Nombre;
                    busqueda.ApellidoPaterno = !string.IsNullOrEmpty(modelo.ApellidoPaterno) ? modelo.ApellidoPaterno : busqueda.ApellidoMaterno;
                    busqueda.ApellidoMaterno = !string.IsNullOrEmpty(modelo.ApellidoMaterno) ? modelo.ApellidoMaterno : busqueda.ApellidoMaterno;
                    busqueda.Rfc = !string.IsNullOrEmpty(modelo.Rfc) ? modelo.Rfc : busqueda.Rfc;
                    busqueda.TarjetaAsignada = modelo.TarjetaAsignada;
                    busqueda.FechaActualizacion = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)"));

                    unit.BeginTransaction();
                    unit.RepositorioCliente.Actualizar(busqueda);
                    unit.SaveChanges();
                    unit.Commit();

                    return new Respuesta<bool>(true);
                }
                else
                {
                    return new Respuesta<bool>("No fue posible encontrar el registro del cliente");
                }
            }
            catch (Exception ex)
            {
                unit.Rollback();

                return new Respuesta<bool>("Ocurrió un error al actualizar el registro del cliente");
            }
        }

        public async Task<Respuesta<bool>> CrearAsync(ClienteDto modelo)
        {

            try
            {
                var busqueda = await unit.RepositorioCliente.ObtenerAsync(q => q.Rfc == modelo.Rfc);

                if (busqueda == null)
                {
                    var cliente = mapper.Map<Cliente>(modelo);

                    cliente.FechaActualizacion = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)"));
                    cliente.FechaRegistro = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)"));

                    unit.BeginTransaction();
                    await unit.RepositorioCliente.CrearAsync(cliente);
                    unit.SaveChanges();
                    unit.Commit();

                    return new Respuesta<bool>(true);
                }
                else
                {
                    return new Respuesta<bool>("Ya existe un cliente con el mismo RFC");
                }
            }
            catch (Exception ex)
            {
                unit.Rollback();

                return new Respuesta<bool>("Ocurrió un error al registrar al cliente");
            }
        }

        public async Task<Respuesta<bool>> EliminarAsync(int id)
        {
            try
            {
                var busqueda = await unit.RepositorioCliente.ObtenerAsync(q => q.ClienteID == id);

                if (busqueda != null)
                {
                    unit.BeginTransaction();
                    unit.RepositorioCliente.Eliminar(busqueda);
                    unit.SaveChanges();
                    unit.Commit();

                    return new Respuesta<bool>(true);
                }
                else
                {
                    return new Respuesta<bool>("No fue posible encontrar el registro del cliente");
                }
            }
            catch (Exception ex)
            {
                unit.Rollback();

                return new Respuesta<bool>("Ocurrió un error al eliminar el registro del cliente");
            }
        }

        public async Task<Respuesta<ClienteDto>> ObtenerPorIdAsync(int id)
        {
            try
            {
                var cliente = await unit.RepositorioCliente.ObtenerAsync(q => q.ClienteID == id);

                if(cliente != null)
                {
                    return new Respuesta<ClienteDto>(mapper.Map<ClienteDto>(cliente));
                }
                else
                {
                    return new Respuesta<ClienteDto>("No fue posible encontrar el registro del cliente");
                }
            }
            catch (Exception ex)
            {
                return new Respuesta<ClienteDto>("Ocurrió un error al consultar los clientes");
            }
        }

        public async Task<Respuesta<List<ClienteDto>>> ObtenerListaAsync()
        {
            try
            {
                var clientes = await unit.RepositorioCliente.ObtenerListaAsync();

                if(clientes.Count() > 0)
                {
                    return new Respuesta<List<ClienteDto>>(
                        mapper.Map<List<ClienteDto>>(clientes.OrderBy(q => q.ApellidoPaterno).ThenBy(q => q.ApellidoMaterno).ThenBy(q => q.Nombre).ToList())
                    );
                }
                else
                {
                    return new Respuesta<List<ClienteDto>>("No se encontraron registros de clientes");
                }
            }
            catch (Exception ex)
            {
                return new Respuesta<List<ClienteDto>>("Ocurrió un error al consultar los clientes");
            }
        }

        public async Task<Respuesta<List<ClienteDto>>> ObtenerUsuariosSinTarjetaAsync()
        {
            try
            {
                var clientes = await unit.RepositorioCliente.ObtenerListaAsync(q => q.TarjetaAsignada == false);

                if (clientes.Count() > 0)
                {
                    return new Respuesta<List<ClienteDto>>(mapper.Map<List<ClienteDto>>(clientes));
                }
                else
                {
                    return new Respuesta<List<ClienteDto>>("No se encontraron registros de clientes");
                }
            }
            catch (Exception ex)
            {
                return new Respuesta<List<ClienteDto>>("Ocurrió un error al consultar los clientes");
            }
        }
    }
}