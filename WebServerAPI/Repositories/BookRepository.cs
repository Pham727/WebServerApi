using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebServerAPI.Data;
using WebServerAPI.Models;

namespace WebServerAPI.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddBook(BookModel book)
        {
            var newBook = _mapper.Map<Book>(book);
            _context.Books!.Add(newBook);
            await _context.SaveChangesAsync();  
            return newBook.Id;
        }

        public async Task DeleteBook(int id)
        {
            var deleteBook = _context.Books!.SingleOrDefault(book => book.Id == id);
            if(deleteBook != null)
            {
                _context.Books!.Remove(deleteBook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BookModel>> GetAllBook()
        {
            var books = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookModel>>(books);
        }

        public async Task<BookModel> GetBook(int id)
        {
            var book = await _context.Books!.FindAsync(id);
            return _mapper.Map<BookModel>(book);
        }

        public async Task UpdateBook(int id, BookModel book)
        {
            if (id == book.Id)
            {
                var updateBook = _mapper.Map<Book>(book);
                _context.Books!.Update(updateBook);
                await _context.SaveChangesAsync();
            }
        }
    }
}
