﻿using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.DTOs;
using Entities.Models;
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

        [HttpGet("fabricante")]
        public IActionResult GetAllFabricantes()
        {
            try
            {
                var fabricante = _repository.Fabricante.GetAllFabricantes();
                _logger.LogInfo($"Retornou todos os fabricantes do banco de dados.");

                var fabricanteResult = _mapper.Map<IEnumerable<FabricanteDto>>(fabricante);
                return Ok(fabricanteResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação GetAllFabricantes: {ex.Message}");
                return StatusCode(500, "Erro do Servidor Interno");
            }
        }

        [HttpGet("{id}", Name = "FabricanteById")]
        public IActionResult GetMarcaById(Guid id)
        {
            try
            {
                var fabricante = _repository.Fabricante.GetFabricanteById(id);
                if (fabricante == null)
                {
                    _logger.LogError($"O Fabricante com id: {id}, não foi encontrado no banco de dados.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Fabricante devolvido com id: {id}");

                    var fabricanteResult = _mapper.Map<FabricanteDto>(fabricante);
                    return Ok(fabricanteResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação GetFabricanteById: {ex.Message}");
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
                _logger.LogError($"Algo deu errado dentro da ação GetAllModelos: {ex.Message}");
                return StatusCode(500, "Erro do Servidor Interno");
            }
        }

        [HttpGet("modelos/{id}")]
        public IActionResult GetModeloWithDetails(Guid id)
        {
            try
            {
                var modelo = _repository.Modelo.GetModeloWithDetails(id);

                var teste = modelo.FabricanteId;
                
                var fabricante = _repository.Fabricante.GetFabricanteById(teste);

                modelo.Fabricante = fabricante;

                if (modelo == null)
                {
                    _logger.LogError($"O modelo com id: {id}, não foi encontrado no banco de dados.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Modelo retornado com detalhes para id: {id}");

                    var modeloResult = _mapper.Map<ModeloDto>(modelo);
                    var fabricanteResult = _mapper.Map<FabricanteDto>(fabricante);

                   
                    return Ok(modeloResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação GetModeloWithDetails: {ex.Message}");
                return StatusCode(500, "Erro do Servidor Interno");
            }
        }

        [HttpPost("modelos")]
        public IActionResult CreateModelo([FromBody]ModeloForCreationDto modelo)
        {
            try
            {
                if (modelo == null)
                {
                    _logger.LogError("O objeto marca enviado do cliente é nulo.");
                    return BadRequest("O objeto marca é nulo");
                }

                if(!ModelState.IsValid)
                {
                    _logger.LogError("Objeto marca inválido enviado do cliente.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var modeloEntity = _mapper.Map<ModeloModels>(modelo);

                _repository.Modelo.CreateModelo(modeloEntity);
                _repository.Save();

                var createdModelo = _mapper.Map<ModeloDto>(modeloEntity);

                return CreatedAtRoute("MarcaById", new { id = createdModelo.Id }, createdModelo);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação CreateModelo: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("modelos/{id}")]
        public IActionResult UpdateModelo(Guid id, [FromBody]ModeloForUpdateDto modelo)
        {
            try
            {
                if(modelo == null)
                {
                    _logger.LogError("O objeto modelo enviado do cliente é nulo.");
                    return BadRequest("O objeto modelo é nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto modelo inválido enviado do cliente.");
                    return BadRequest("Objeto de modelo inválido");
                }

                var modeloEntity = _repository.Modelo.GetModeloById(id);

                if(modeloEntity == null)
                {
                    _logger.LogError($"Modelo com id: {id}, não foi encontrado no banco de dados.");
                    return NotFound();
                }

                _mapper.Map(modelo, modeloEntity);

                _repository.Modelo.UpdateModelo(modeloEntity);
                _repository.Save();

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação UpdateModelo: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("modelos/{id}")]
        public IActionResult DeleteModelo(Guid id)
        {
            try
            {
                var modelo = _repository.Modelo.GetModeloById(id);

                if(modelo == null)
                {
                    _logger.LogError($"Modelo com id: {id}, não foi encontrado no banco de dados.");
                    return NotFound();
                }

                _repository.Modelo.DeleteModelo(modelo);
                _repository.Save();

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Algo deu errado dentro da ação DeleteModelo: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
