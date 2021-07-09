using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ContaCorrente_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly ILogger<ContaCorrenteController> _logger;

        public ContaCorrenteController(ILogger<ContaCorrenteController> logger)
        {
            _logger = logger;
        }
    }
}
