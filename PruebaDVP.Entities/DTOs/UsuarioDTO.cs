using System;
namespace PruebaDVP.Entities.DTOs
{
    public class UsuarioDTO
    {
        public int Identificador { get; set; }

        public string NombreUsuario { get; set; } = null!;

        public string Pass { get; set; } = null!;

        public DateTime FechaCreacion { get; set; }
    }
}

