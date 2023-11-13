using System;
using AutoMapper;
using System.Data;
using PruebaDVP.Entities.DTOs;
using PruebaDVP.Data.Models.DB;

namespace PruebaDVP.Core.MapperDTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Persona, PersonaDTO>().ForMember(dest =>
                    dest.Usuario,
                    opt => opt.Ignore()
                );
            CreateMap<PersonaDTO, Persona>().ForMember(dest =>
                   dest.TipoIdentificacionNavigation,
                   opt => opt.Ignore()
               ).ForMember(dest =>
                   dest.Usuario,
                   opt => opt.Ignore()
               );
            CreateMap<Usuario, UsuarioDTO>();

            CreateMap<UsuarioDTO, Usuario>().ForMember(dest =>
                    dest.IdentificadorNavigation,
                    opt => opt.Ignore()
                );

            CreateMap<TipoIdentificacion, TipoIdentificacionDTO>();

            CreateMap<TipoIdentificacionDTO, TipoIdentificacion>().ForMember(dest =>
                    dest.Personas,
                    opt => opt.Ignore()
                );

        }
    }
}

