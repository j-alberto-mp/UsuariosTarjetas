using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Usuarios.Repositorios
{
    public abstract class RepositorioBase<T>  where T : class
    {
        protected readonly DbSet<T> entidad;
        
        public RepositorioBase(DbContext context)
        {
            entidad = context.Set<T>();
        }

        public async Task CrearAsync(T entity)
        {
            _ = await entidad.AddAsync(entity);
        }

        public void Actualizar(T entity)
        {
            entidad.Update(entity);
        }

        public void Eliminar(T entity)
        {
            entidad.Remove(entity);
        }

        public async Task<T> ObtenerAsync(Expression<Func<T, bool>> condicion)
        {
            return await entidad.Where(condicion).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ObtenerListaAsync()
        {
            return await entidad.ToListAsync();
        }

        public async Task<List<T>> ObtenerListaAsync(Expression<Func<T, bool>> condicion)
        {
            return await entidad.Where(condicion).ToListAsync();
        }
    }
}