using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicStore.Dto;
using MusicStore.Entities;
using MusicStore.Repositories;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Music_Store.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GenresController: ControllerBase
    {
        private readonly IGenreRepository _repository;
        private readonly ILogger<GenresController> _logger;

        public GenresController(IGenreRepository repository, ILogger<GenresController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new BaseResponseGeneric<ICollection<Genre>>();
            try
            {
                response.Data = await _repository.List();
                response.Sucess = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al listar los Generos";
                _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Genre genre)
        {
            await _repository.Add(genre);
            return CreatedAtAction(nameof(Get), new
            {
                genre.Id
            });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response=await _repository.FindById(id);
            return response!=null ? Ok(response) : NotFound();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]Genre genre)
        {
            var response = new BaseResponse();
            try
            {
                await _repository.Update(id, genre);
                response.Sucess = true;
                return Accepted(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al actualizar el Genero";
                _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
                return NotFound(response);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);
                return BadRequest(new { Mensaje = "Error al eliminar" });
            }
        }
    }
}
