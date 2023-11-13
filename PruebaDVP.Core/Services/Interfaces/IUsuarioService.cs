using System;
using PruebaDVP.Data.Models.DB;
using PruebaDVP.Entities.DTOs;

namespace PruebaDVP.Core.Services.Interfaces
{
    public interface IUsuarioService : IService<Usuario, UsuarioDTO>
    {
        Task<UsuarioDTO?> ObtenerUsuario(string nombreUsuario);

    }
}

