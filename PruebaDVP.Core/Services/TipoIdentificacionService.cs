using System;
using AutoMapper;
using PruebaDVP.Core.Services.Interfaces;
using PruebaDVP.Data.Models.DB;
using PruebaDVP.Data.Services.Interfaces;
using PruebaDVP.Entities.DTOs;

namespace PruebaDVP.Core.Services
{
    public class TipoIdentificacionService : Service<TipoIdentificacion, TipoIdentificacionDTO>, ITipoIdentificacionService
    {
        public TipoIdentificacionService(ITipoIdentificacionContextService context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}

