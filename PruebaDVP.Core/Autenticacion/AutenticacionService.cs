using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using PruebaDVP.Core.Autenticacion.Interfaces;
using PruebaDVP.Core.Services.Interfaces;
using PruebaDVP.Entities.Autenticacion;
using PruebaDVP.Entities.DTOs;

namespace PruebaDVP.Core.Autenticacion
{
    public class AutenticacionService : IAutenticacionService
    {


        private readonly IUsuarioService _usuarioService;
        private readonly IPersonaService _personaService;
        private readonly ITipoIdentificacionService _tipoIdentificacionService;

        public AutenticacionService(IUsuarioService usuarioService, IPersonaService personaService, ITipoIdentificacionService tipoIdentificacionService)
        {

            _personaService = personaService;
            _usuarioService = usuarioService;
            _tipoIdentificacionService = tipoIdentificacionService;
        }

        public async Task<bool> Login(LoginDTO login)
        {
            try
            {
                UsuarioDTO? usuario = await _usuarioService.ObtenerUsuario(login.NombreUsuario) ?? throw new UnauthorizedAccessException("Credenciales invalidas - Nombre Usuario");

                if (!ValidarPassword(login, usuario))
                    throw new UnauthorizedAccessException("Credenciales invalidas - Password");


                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<PersonaDTO> RegistrarPersona(RegistroDTO registro)
        {
            try
            {
                await ValidarNombreUsuario(registro.NombreUsuario);
                await ValidarNumeroIdentificacion(registro.NumeroIdentificacion);
                TipoIdentificacionDTO? tipo = await _tipoIdentificacionService.Get(registro.TipoIdentificacion) ?? throw new Exception("Tipo de identificacion invalido");

                PersonaDTO persona = new PersonaDTO();
                persona.Apellidos = registro.Apellidos;
                persona.Email = registro.Email;
                persona.FechaCreacion = DateTime.Now;
                persona.Identificacion = tipo.Nombre + " " + registro.NumeroIdentificacion;
                persona.NombreCompleto = registro.Nombres + " " + registro.Apellidos;
                persona.Nombres = registro.Nombres;
                persona.NombreTipoIdentificacion = tipo.Nombre;
                persona.NumeroIdentificacion = registro.NumeroIdentificacion;
                persona.TipoIdentificacion = registro.TipoIdentificacion;

                persona = await _personaService.Add(persona);

                UsuarioDTO usuario = new UsuarioDTO();
                usuario.FechaCreacion = DateTime.Now;
                usuario.Identificador = persona.Identificador;
                usuario.NombreUsuario = registro.NombreUsuario;
                usuario.Pass = BCrypt.Net.BCrypt.HashPassword(registro.Pass);
                usuario = await _usuarioService.Add(usuario);
                persona.Usuario = usuario;
                return persona;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task ValidarNumeroIdentificacion(int numeroIdentificacion)
        {
            try
            {
                PersonaDTO? persona = await _personaService.ObtenerPersona(numeroIdentificacion);
                if (persona != null)
                    throw new Exception("ya existe una persona con este numero de identificacion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task ValidarNombreUsuario(string nombreUsuario)
        {
            try
            {
                UsuarioDTO? usuario = await _usuarioService.ObtenerUsuario(nombreUsuario);
                if (usuario != null)
                    throw new Exception("este nombre de usuario ya existe en la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private bool ValidarPassword(LoginDTO login, UsuarioDTO usuario)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(login.Password, usuario.Pass);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}

