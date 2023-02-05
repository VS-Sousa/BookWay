using BookWayApi.Modules.Books.Dtos;
using BookWayApi.Modules.Books.Models;
using BookWayApi.Modules.Books.Repositories;
using BookWayApi.Modules.Genres.Models;
using BookWayApi.Modules.Genres.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookWayApi.Modules.Books.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<JsonResult> GetBooksAsync()
        {
            return new JsonResult(await booksRepository.GetBooksAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookByIdAsync(Guid id)
        {
            var book = await booksRepository.GetBookByIdAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBookAsync(CreateBookDto createBookDto)
        {
            Book book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = createBookDto.Title,
                Genre = createBookDto.Genre
            };

            await booksRepository.CreateBookAsync(book);

            return CreatedAtAction(nameof(GetBookByIdAsync), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBookAsync(Guid id, UpdateBookDto updateBookDto)
        {
            var book = await booksRepository.GetBookByIdAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            book.Title = updateBookDto.Title;
            book.Genre = updateBookDto.Genre;

            await booksRepository.UpdateBookAsync(book);

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookAsync(Guid id)
        {
            Book book = await booksRepository.GetBookByIdAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await booksRepository.DeleteBookAsync(id);

            return NoContent();
        }
    }
}
