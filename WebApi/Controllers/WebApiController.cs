using Contracts;
using Microsoft.AspNetCore.Mvc;
using webapi.core.contracts;

namespace WebApi.Controllers
{
    [Route("api/veiculos")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public WebApiController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var owners = _repository.Veiculo.GetAllOwners();
                _logger.LogInfo($"Retornou todos os proprietários do banco de dados.");
                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação GetAllOwners: {ex.Message}");
                return StatusCode(500, "Erro do Servidor Interno");
            }
        }
    }
}
