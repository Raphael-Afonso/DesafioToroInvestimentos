using ContaCorrente_Backend.Context;
using ContaCorrente_Backend.Models;
using ContaCorrente_Backend.Repositories;
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

        public ContaCorrenteController(
            ILogger<ContaCorrenteController> logger,
            DbContextOptions<SQLContext> options)
        {
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
    }
}
