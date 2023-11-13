using System;
namespace PruebaDVP.Entities.DTOs
{
    public class PersonaDTO
    {
        public int Identificador { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public int NumeroIdentificacion { get; set; }

        public string Email { get; set; } = null!;

        public int TipoIdentificacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Identificacion { get; set; } = null!;

        public string? NombreCompleto { get; set; }

        public string NombreTipoIdentificacion { get; set; } = null!;

        public UsuarioDTO? Usuario { get; set; }

    }
}

