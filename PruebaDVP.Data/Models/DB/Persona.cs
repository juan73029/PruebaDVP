using System;
using System.Collections.Generic;

namespace PruebaDVP.Data.Models.DB;

public partial class Persona
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

    public virtual TipoIdentificacion TipoIdentificacionNavigation { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
