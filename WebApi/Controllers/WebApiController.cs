using Microsoft.AspNetCore.Mvc;
using webapi.core.contracts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebApiController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public WebApiController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info message from the controller.");
            _logger.LogDebug("Here is debug message from the controller.");
            _logger.LogWarning("Here is warn message from the controller.");
            _logger.LogError("Here is error message from the controller.");
            return new string[] { "value1", "value2" };
        }
    }
}
