using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDVP.Core.Services.Interfaces;
using PruebaDVP.Entities.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaDVP.Aplicacion.Controllers
{
    [Route("api/[controller]")]
    public class TipoIdentificacionController : Controller
    {
        private readonly ITipoIdentificacionService _tipoIdentificacionService;
        public TipoIdentificacionController(ITipoIdentificacionService tipoIdentificacionService)
        {
            _tipoIdentificacionService = tipoIdentificacionService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<TipoIdentificacionDTO>>> Get()
        {
            try
            {
                return Ok(await _tipoIdentificacionService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}

