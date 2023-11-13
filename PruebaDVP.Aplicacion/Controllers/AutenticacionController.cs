using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using PruebaDVP.Core.Autenticacion.Interfaces;
using PruebaDVP.Entities.Autenticacion;
using PruebaDVP.Entities.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaDVP.Aplicacion.Controllers
{
    [Route("api/[controller]")]
    public class AutenticacionController : Controller
    {
        // GET: api/values
        private readonly IAutenticacionService _autenticacionService;
        public AutenticacionController(IAutenticacionService autenticacionService)
        {
            _autenticacionService = autenticacionService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<bool>> Login([FromBody] LoginDTO login)
        {
            try
            {
                return Ok(await _autenticacionService.Login(login));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Registro")]
        public async Task<ActionResult<PersonaDTO>> Registro([FromBody] RegistroDTO registro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _autenticacionService.RegistrarPersona(registro));
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
    }
}

