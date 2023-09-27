using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicStore.Entities;
using MusicStore.Repositories;

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
        public List<Genre> Get()
        {
            return _repository.List();
        }

        [HttpPost]
        public int Post([FromBody]Genre genre)
        {
            _repository.Add(genre);
            return genre.Id;
        }

        [HttpGet("{id:int}")]
        public Genre? Get(int id)
        {
            return _repository.FindById(id);
        }

        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody]Genre genre)
        {
            _repository.Update(id, genre);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);
                //return Results.BadRequest(new { Mensaje = "Error al eliminar" });
            }
        }
    }
}
