namespace Usuarios.Core.Utilidades
{
    public class Respuesta<T>
    {
        public Respuesta(T datos, string mensaje = null)
        {
            Correcto = true;
            Mensaje = mensaje;
            Datos = datos;
        }

        public Respuesta(string mensaje)
        {
            Correcto = false;
            Mensaje = mensaje;
        }

        public bool Correcto { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }
    }
}