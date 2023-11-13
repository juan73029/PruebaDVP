using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaDVP.Entities.Autenticacion
{
    public class RegistroDTO
    {

        [Required(ErrorMessage = "Nombres no encontrado ")]
        [StringLength(100, MinimumLength = 2)]
        public string Nombres { get; set; } = null!;

        [Required(ErrorMessage = "Apellidos no encontrado ")]
        [StringLength(100, MinimumLength = 2)]
        public string Apellidos { get; set; } = null!;

        [Required(ErrorMessage = "Numero de identificacion no encontrado ")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor ingrese un valor valido para numero de identificacion")]
        public int NumeroIdentificacion { get; set; }


        [StringLength(100, MinimumLength = 5)]
        [EmailAddress]
        [Required(ErrorMessage = "Email no encontrado")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Por favor ingrese un email correcto")]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Tipo de identificacion no encontrado ")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor ingrese un valor valido para tipo de identificacion")]
        public int TipoIdentificacion { get; set; }


        [Required(ErrorMessage = "Nombre usuario no encontrado ")]
        [StringLength(100, MinimumLength = 2)]
        public string NombreUsuario { get; set; } = null!;

        [Required(ErrorMessage = "Pass no encontrado ")]
        [StringLength(100, MinimumLength = 6)]
        public string Pass { get; set; } = null!;
    }
}

