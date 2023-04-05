using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id}", Name = "MarcaById")]

        public IActionResult GetMarcaById(Guid id)
        {
            try
            {
                var marca = _repository.Marca.GetMarcaById(id);
                if (marca == null)
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
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação GetOwnerById: {ex.Message}");
                return StatusCode(500, "Erro do Servidor Interno");
            }
        }

        [HttpPost]
        public IActionResult CreateMarca([FromBody]MarcaForCreationDto marca)
        {
            try
            {
                if (marca == null)
                {
                    _logger.LogError("O objeto marca enviado do cliente é nulo.");
                    return BadRequest("O objeto marca é nulo");
                }

                if(!ModelState.IsValid)
                {
                    _logger.LogError("Objeto marca inválido enviado do cliente.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var marcaEntity = _mapper.Map<MarcaModels>(marca);

                _repository.Marca.CreateMarca(marcaEntity);
                _repository.Save();

                var createdMarca = _mapper.Map<MarcaDto>(marcaEntity);

                return CreatedAtRoute("MarcaById", new { id = createdMarca.Id }, createdMarca);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação CreateOwner: {ex.Message}");
                return StatusCode(500, "Internal server error");
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

        [HttpGet("modelos/{id}")]
        public IActionResult GetModeloWithDetails(Guid id)
        {
            try
            {
                var modelo = _repository.Modelo.GetModeloWithDetails(id);
                if (modelo == null)
                {
                    _logger.LogError($"O modelo com id: {id}, não foi encontrado no banco de dados.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Modelo retornado com detalhes para id: {id}");

                    var modeloResult = _mapper.Map<ModeloDto>(modelo);
                    return Ok(modeloResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação GetOwnerWithDetails: {ex.Message}");
                return StatusCode(500, "Erro do Servidor Interno");
            }
        }
    }
}
