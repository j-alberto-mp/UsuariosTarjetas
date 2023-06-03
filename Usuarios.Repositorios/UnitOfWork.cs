using Microsoft.EntityFrameworkCore.Storage;
using System;
using Usuarios.Core.Contratos.Factories;
using Usuarios.Core.Contratos.Repositorios;

namespace Usuarios.Repositorios
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IRepositorioCliente repositorioCliente;
        private IRepositorioTarjetaCliente repositorioTarjetaCliente;
        private readonly UsuariosContext context;
        private bool disposed;
        private IDbContextTransaction objTran;

        public UnitOfWork(UsuariosContext context) => this.context = context;

        public IRepositorioCliente RepositorioCliente
        {
            get
            {
                //if (repositorioCliente == null)
                //{
                //    repositorioCliente = new RepositorioCliente(context);
                //}

                return new RepositorioCliente(context);
            }
        }

        public IRepositorioTarjetaCliente RepositorioTarjetaCliente
        {
            get
            {
                //if(repositorioTarjetaCliente == null)
                //{
                //    repositorioTarjetaCliente = new RepositorioTarjetaClientes(context);
                //}

                return new RepositorioTarjetaClientes(context);
            }
        }

        public void BeginTransaction()
        {
            objTran = context.Database.BeginTransaction();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Commit()
        {
            objTran.Commit();
        }

        public void Rollback()
        {
            objTran.Rollback();
            objTran.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }
    }
}