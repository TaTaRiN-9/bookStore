using Microsoft.AspNetCore.Mvc;
using TestWebApi.API.Contracts;
using TestWebApi.Application.Services;
using TestWebApi.Core.Models;

namespace TestWebApi.API.Controllers
{
    [ApiController]
    [Route("book")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksServices _booksServices;
        public BooksController(IBooksServices booksServices)
        {
            _booksServices = booksServices;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _booksServices.GetAllBooks();

            var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));
            
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateBook([FromBody] BooksRequest booksRequest)
        {
            var (book, error) = Book.Create(
                booksRequest.Title,
                booksRequest.Description,
                booksRequest.Price);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var bookId = await _booksServices.CreateBook(book);

            return Ok(bookId);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Guid>> UpdateBook(int id, [FromBody] BooksRequest booksRequest)
        {
            var bookId = await _booksServices.UpdateBook(id, booksRequest.Title, booksRequest.Description, booksRequest.Price);

            return Ok(bookId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteBook(int id)
        {
            return Ok(await _booksServices.DeleteBook(id));
        }
    }
}
