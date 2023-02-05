using BookWayApi.Modules.Genres.Dtos;
using BookWayApi.Modules.Genres.Models;
using BookWayApi.Modules.Genres.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookWayApi.Modules.Genres.Controllers
{
    [Route("genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresRepository genresRepository;

        public GenresController(IGenresRepository genreRepository)
        {
            genresRepository = genreRepository;
        }

        [HttpGet]
        public async Task<JsonResult> GetGenresAsync()
        {
            return new JsonResult(await genresRepository.GetGenresAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenreAsync(Guid id)
        {
            var genre = await genresRepository.GetGenreByIdAsync(id);

            if (genre is null)
            {
                return NotFound();
            }

            return genre;
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> AddGenreAsync(AddGenreDto addGenreDto)
        {
            Genre genre = new Genre()
            {
                Name = addGenreDto.Name,
                Id = Guid.NewGuid()
            };

            await genresRepository.AddGenreAsync(genre);

            return CreatedAtAction(nameof(GetGenreAsync), new { id = genre.Id }, genre);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Genre>> UpdateGenreAsync(Guid id, UpdateGenreDto updateGenreDto)
        {
            Genre genre = await genresRepository.GetGenreByIdAsync(id);

            if (genre is null)
            {
                return NotFound();
            }

            genre.Name = updateGenreDto.Name;

            await genresRepository.UpdateGenreAsync(genre);

            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenreAsync(Guid id)
        {
            Genre genre = await genresRepository.GetGenreByIdAsync(id);

            if (genre is null)
            {
                return NotFound();
            }

            await genresRepository.DeleteGenreAsync(id);

            return NoContent();
        }
    }
}
