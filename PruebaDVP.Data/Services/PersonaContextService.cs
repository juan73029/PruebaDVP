using System;
using Microsoft.EntityFrameworkCore;
using PruebaDVP.Data.Models.DB;
using PruebaDVP.Data.Services.Interfaces;

namespace PruebaDVP.Data.Services
{
    public class PersonaContextService : ContextService<Persona>, IPersonaContextService
    {
        private readonly PruebaDoubleVpartnersContext _context;
        public PersonaContextService(PruebaDoubleVpartnersContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Persona>> ObtenerPersonasCreadas()
        {
            try
            {

                List<Persona> q = await _context.Personas.FromSql($"EXECUTE dbo.SpPersonasCreadas").ToListAsync();
                return q;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Persona?> ObtenerPersona(int numeroIdentificacion)
        {
            try
            {

                return await _context.Personas.FirstOrDefaultAsync(p => p.NumeroIdentificacion == numeroIdentificacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

