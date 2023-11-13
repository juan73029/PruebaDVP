using System;
using System.Collections.Generic;

namespace PruebaDVP.Data.Models.DB;

public partial class Usuario
{
    public int Identificador { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual Persona IdentificadorNavigation { get; set; } = null!;
}
