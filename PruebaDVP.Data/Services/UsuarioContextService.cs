using System;
using Microsoft.EntityFrameworkCore;
using PruebaDVP.Data.Models.DB;
using PruebaDVP.Data.Services.Interfaces;

namespace PruebaDVP.Data.Services
{
    public class UsuarioContextService : ContextService<Usuario>, IUsuarioContextService
    {
        PruebaDoubleVpartnersContext _context;
        public UsuarioContextService(PruebaDoubleVpartnersContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerUsuario(string nombreUsuario)
        {
            try
            {
                return await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario.Trim());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

