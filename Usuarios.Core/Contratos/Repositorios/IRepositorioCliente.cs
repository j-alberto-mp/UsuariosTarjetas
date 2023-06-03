using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Usuarios.Core.Entidades;

namespace Usuarios.Core.Contratos.Repositorios
{
    public interface IRepositorioCliente
    {
        /// <summary>
        /// Agrega un nuevo cliente a la base de datos
        /// </summary>
        /// <param name="cliente"></param>
        Task CrearAsync(Cliente cliente);

        /// <summary>
        /// Actualiza un cliente de la base de datos
        /// </summary>
        /// <param name="cliente"></param>
        void Actualizar(Cliente cliente);

        /// <summary>
        /// Elimina un cliente de la base de datos
        /// </summary>
        /// <param name="cliente"></param>
        void Eliminar(Cliente cliente);

        /// <summary>
        /// Obtiene un cliente, en base a una condicón
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns></returns>
        Task<Cliente> ObtenerAsync(Expression<Func<Cliente, bool>> condicion);

        /// <summary>
        /// Obtiene la lista de todos los clientes
        /// </summary>
        /// <returns></returns>
        Task<List<Cliente>> ObtenerListaAsync();

        /// <summary>
        /// Obtiene la lista de todos los clientes, en base a una condición
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns></returns>
        Task<List<Cliente>> ObtenerListaAsync(Expression<Func<Cliente, bool>> condicion);
    }
}