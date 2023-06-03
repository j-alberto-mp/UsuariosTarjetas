using System.ComponentModel.DataAnnotations;

namespace Usuarios.Core.Dtos
{
    public class ClienteDto
    {
        public int ClienteID { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(30, ErrorMessage = "La longitud máxima es de 30 caracteres")]
        [MinLength(3, ErrorMessage = "La longitud mínima es de 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido Paterno es requerido")]
        [MaxLength(70, ErrorMessage = "La longitud máxima es de 70 caracteres")]
        [MinLength(4, ErrorMessage = "La longitud mínima es de 4 caracteres")]
        [Display(Name = "Apellido paterno")]
        public string ApellidoPaterno { get; set; }

        [MaxLength(70, ErrorMessage = "La longitud máxima es de 70 caracteres")]
        [MinLength(4, ErrorMessage = "La longitud mínima es de 4 caracteres")]
        [Display(Name = "Apellido materno")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El campo RFC es requerido")]
        [MaxLength(13, ErrorMessage = "La longitud máxima es de 13 caracteres")]
        [MinLength(10, ErrorMessage = "La longitud mínima es de 10 caracteres")]
        [Display(Name = "RFC")]
        public string Rfc { get; set; }

        public bool TarjetaAsignada { get; set; }
    }
}