using System.Collections.Generic;
using System.Linq;
using books_api.Model;
using books_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace books_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IBookService bookService;

        public BooksController(IBookService bookService,
                             ILogger<BooksController> logger)
        {
            this.logger = logger;
            this.bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>>  Get()
        {
            var books = bookService.GetAllBooks();

            if(!books.Any())
                return NoContent();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public  ActionResult<Book> Get(int id)
        {
            var book = bookService.GetBookById(id);

            if(book == null)
                return NoContent();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            try
            {
                bookService.AddBook(book);
                return CreatedAtAction(nameof(Get),new {id = book.Id },book);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);                
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            try
            {
                var deleted = bookService.DeleteBook(id);
                
                if(deleted == null)
                    return NotFound();
                
                logger.LogInformation("success to delete the book.");
                    return Ok(deleted);                     
            }
            catch (System.Exception e)
            {
                logger.LogError(e,"error while trying to delete book");

                return StatusCode(StatusCodes.Status500InternalServerError);                
            }
        }
    }
}