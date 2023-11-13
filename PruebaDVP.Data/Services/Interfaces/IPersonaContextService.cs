using System;
using PruebaDVP.Data.Models.DB;

namespace PruebaDVP.Data.Services.Interfaces
{
    public interface IPersonaContextService : IContextService<Persona>
    {
        Task<List<Persona>> ObtenerPersonasCreadas();
        Task<Persona?> ObtenerPersona(int numeroIdentificacion);
    }
}

