using System;
using AutoMapper;
using PruebaDVP.Core.Services.Interfaces;
using PruebaDVP.Data.Models.DB;
using PruebaDVP.Data.Services.Interfaces;
using PruebaDVP.Entities.DTOs;

namespace PruebaDVP.Core.Services
{
    public class PersonaService : Service<Persona, PersonaDTO>, IPersonaService
    {
        private readonly IPersonaContextService _context;
        private readonly IMapper _mapper;
        public PersonaService(IPersonaContextService context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonaDTO?> ObtenerPersona(int numeroIdentificacion)
        {
            try
            {
                return _mapper.Map<PersonaDTO?>(await _context.ObtenerPersona(numeroIdentificacion));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PersonaDTO>> ObtenerPersonasCreadas()
        {
            try
            {
                return _mapper.Map<List<PersonaDTO>>(await _context.ObtenerPersonasCreadas());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

