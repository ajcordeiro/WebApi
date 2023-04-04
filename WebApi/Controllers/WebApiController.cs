using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using webapi.core.contracts;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public WebApiController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("marcas")]
        public IActionResult GetAllMarcas()
        {
            try
            {
                var marca = _repository.Marca.GetAllMarcas();
                _logger.LogInfo($"Retornou todos os proprietários do banco de dados.");

                var marcaResult = _mapper.Map<IEnumerable<MarcaDto>>(marca);
                return Ok(marcaResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação GetAllOwners: {ex.Message}");
                return StatusCode(500, "Erro do Servidor Interno");
            }
        }

        [HttpGet("marcas/{id}")]
        public IActionResult GetMarcaById(Guid id)
        {
            try
            {
                var marca = _repository.Marca.GetMarcaById(id);
                if(marca == null)
                {
                    _logger.LogError($"A Marca com id: {id}, não foi encontrado no banco de dados.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Marca devolvido com id: {id}");

                    var marcaResult = _mapper.Map<MarcaDto>(marca);
                    return Ok(marcaResult);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação GetOwnerById: {ex.Message}");
                return StatusCode(500, "Erro do Servidor Interno");
            }
        }

        [HttpGet("modelos")]
        public IActionResult GetAllModelos()
        {
            try
            {
                var modelo = _repository.Modelo.GetAllModelos();
                _logger.LogInfo($"Retornou todos os modelos do banco de dados.");

                var modeloResult = _mapper.Map<IEnumerable<ModeloDto>>(modelo);
                return Ok(modeloResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação GetAllOwners: {ex.Message}");
                return StatusCode(500, "Erro do Servidor Interno");
            }
        }

        //[HttpGet("{id}/modelos")]
        //public IActionResult GetModeloWithDetails(Guid id)
        //{
        //    try
        //    {
        //        var modelo = _repository.Modelo.GetModeloWithDetails(id);
        //        if(modelo == null)
        //        {
        //            _logger.LogError($"O modelo com id: {id}, não foi encontrado no banco de dados.");
        //            return NotFound();
        //        }
        //        else
        //        {
        //            _logger.LogInfo($"Modelo retornado com detalhes para id: {id}");

        //            var modeloResult = _mapper.Map<MarcaDto>(modelo);
        //            return Ok(modeloResult);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        _logger.LogError($"Algo deu errado dentro da ação GetOwnerWithDetails: {ex.Message}");
        //        return StatusCode(500, "Erro do Servidor Interno");
        //    }
        //}
    }
}
