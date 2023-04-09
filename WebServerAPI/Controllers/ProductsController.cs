using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServerAPI.Models;
using WebServerAPI.Repositories;

namespace WebServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public ProductsController(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            try
            {
                return Ok(await _bookRepo.GetAllBook());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookRepo.GetBook(id);
                return book == null ? NotFound() : Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                var newBookId = await _bookRepo.AddBook(model);
                var book = await _bookRepo.GetBook(newBookId);
                return book == null ? NotFound() : Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookModel book)
        {
            try
            {
                if (id != book.Id)
                {
                    return NotFound();
                }
                await _bookRepo.UpdateBook(id, book);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                //check book in database
                var book = await _bookRepo.GetBook(id);
                if (book == null)
                {
                    return NotFound();
                }
                await _bookRepo.DeleteBook(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
