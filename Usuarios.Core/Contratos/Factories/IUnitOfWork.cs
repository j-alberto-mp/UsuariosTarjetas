using Usuarios.Core.Contratos.Repositorios;

namespace Usuarios.Core.Contratos.Factories
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Repositorio del cliente
        /// </summary>
        IRepositorioCliente RepositorioCliente { get; }

        /// <summary>
        /// Repositorio de las tarjetas
        /// </summary>
        IRepositorioTarjetaCliente RepositorioTarjetaCliente { get; }

        /// <summary>
        /// Iniciar una transacción
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Guardar los cambios
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Confirmar los cambios
        /// </summary>
        void Commit();

        /// <summary>
        /// Deshacer los cambios
        /// </summary>
        void Rollback();

        /// <summary>
        /// Liberar los recursos
        /// </summary>
        void Dispose();
    }
}