using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuarios.Core.Entidades
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteID { get; set; }
        [MaxLength(30)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(70)]
        [Required]
        public string ApellidoPaterno { get; set; }
        [MaxLength(70)]
        public string ApellidoMaterno { get; set; }
        [MaxLength(13)]
        [Required]
        public string Rfc { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool TarjetaAsignada { get; set; }
    }
}