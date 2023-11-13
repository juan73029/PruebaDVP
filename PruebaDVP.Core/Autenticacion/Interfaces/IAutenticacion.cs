using System;
using PruebaDVP.Entities.Autenticacion;
using PruebaDVP.Entities.DTOs;

namespace PruebaDVP.Core.Autenticacion.Interfaces
{
    public interface IAutenticacionService
    {
        Task<bool> Login(LoginDTO login);
        Task<PersonaDTO> RegistrarPersona(RegistroDTO registro);

    }
}

