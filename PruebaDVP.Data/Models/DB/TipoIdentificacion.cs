using System;
using System.Collections.Generic;

namespace PruebaDVP.Data.Models.DB;

public partial class TipoIdentificacion
{
    public int Identificador { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
