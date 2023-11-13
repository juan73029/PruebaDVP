using System;
using PruebaDVP.Data.Models.DB;

namespace PruebaDVP.Data.Services.Interfaces
{
    public interface IUsuarioContextService : IContextService<Usuario>
    {
        Task<Usuario?> ObtenerUsuario(string nombreUsuario);

    }
}

