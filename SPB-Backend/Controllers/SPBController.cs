using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPB_Backend.Models;
using System.Threading.Tasks;

namespace SPB_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SPBController : ControllerBase
    {
        private readonly ILogger<SPBController> _logger;

        public SPBController(ILogger<SPBController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> PostSPB(SPB spb)
        {
            return Ok();
        }
    }
}
