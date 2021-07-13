using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPB_Backend.Models;
using SPB_Backend.Services;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace SPB_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SPBController : ControllerBase
    {
        private readonly ILogger<SPBController> _logger;
        private readonly SPBService _service;


        public SPBController(ILogger<SPBController> logger, IConfiguration parametros)
        {
            _logger = logger;
            _service = new(parametros);
        }

        [HttpPost]
        public async Task<ActionResult> PostSPB(SPB spb)
        {
            try
            {
                await _service.EnviarMovimentoParaContaCorrente(spb);
                return Ok();
            }
            catch (ApplicationException)
            {
                return StatusCode(StatusCodes.Status424FailedDependency);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
