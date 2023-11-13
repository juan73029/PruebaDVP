using System;
using AutoMapper;
using PruebaDVP.Core.Services.Interfaces;
using PruebaDVP.Data.Models.DB;
using PruebaDVP.Data.Services.Interfaces;
using PruebaDVP.Entities.DTOs;

namespace PruebaDVP.Core.Services
{
    public class UsuarioService : Service<Usuario, UsuarioDTO>, IUsuarioService
    {
        private readonly IUsuarioContextService _context;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioContextService context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO?> ObtenerUsuario(string nombreUsuario)
        {
            try
            {
                return _mapper.Map<UsuarioDTO?>(await _context.ObtenerUsuario(nombreUsuario));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

