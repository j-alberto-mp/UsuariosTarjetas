using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Usuarios.Core.Entidades
{
    public class TarjetaCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TarjetaClienteID { get; set; }
        public int ClienteID { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaVencimiento { get; set; }
        public string Cvv { get; set; }
        public string Emisor { get; set; }
    }
}