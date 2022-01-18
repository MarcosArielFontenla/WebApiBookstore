using Bookstore.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bookstore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;

        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookServices.GetBooks());
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<IActionResult> GetBookById(string id)
        {
            return Ok(await _bookServices.GetBookById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _bookServices.AddBook(book);
            return CreatedAtRoute("GetBookbyId", new {id = book.Id}, book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            return Ok(await _bookServices.UpdateBook(book));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            await _bookServices.DeleteBook(id);
            return NoContent();
        }
    }
}
