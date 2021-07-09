using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}
