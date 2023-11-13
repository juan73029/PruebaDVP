using System;
using PruebaDVP.Data.Models.DB;
using PruebaDVP.Entities.DTOs;

namespace PruebaDVP.Core.Services.Interfaces
{
    public interface IPersonaService : IService<Persona, PersonaDTO>
    {
        Task<List<PersonaDTO>> ObtenerPersonasCreadas();
        Task<PersonaDTO?> ObtenerPersona(int numeroIdentificacion);
    }
}

