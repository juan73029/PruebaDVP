using System;
using PruebaDVP.Data.Models.DB;
using PruebaDVP.Data.Services.Interfaces;

namespace PruebaDVP.Data.Services
{
    public class TipoIdentificacionContextService : ContextService<TipoIdentificacion>, ITipoIdentificacionContextService
    {
        public TipoIdentificacionContextService(PruebaDoubleVpartnersContext context) : base(context)
        {
        }
    }
}

