using ContaCorrente_Backend.Context;
using ContaCorrente_Backend.Models;
using ContaCorrente_Backend.Repositories;
using ContaCorrente_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace ContaCorrente_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly ILogger<ContaCorrenteController> _logger;
        private readonly ContaCorrenteRepository _repository;
        private readonly ContaCorrenteService _service;

        public ContaCorrenteController(
            ILogger<ContaCorrenteController> logger,
            DbContextOptions<SQLContext> options)
        {
            _service = new(options);
            _repository = new(options);
            _logger = logger;
        }

        [HttpPost]
        [Route("abrir")]
        public ActionResult<ContaCorrente> PostContaCorrente(
            [FromQuery] string titular,
            [FromQuery] string inscricao,
            [FromQuery] string conta)
        {
            try
            {
                return Created(string.Empty, _repository.CriarContaCorrente(new ContaCorrente(titular, inscricao, conta)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("processarMovimento")]
        public ActionResult<ContaCorrente> PutReceberMovimento(
            [FromBody] MovimentoRequest movimento)
        {
            try
            {
                return Ok(_service.ProcessarMovimento(movimento));
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
