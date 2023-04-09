using WebServerAPI.Data;
using WebServerAPI.Models;

namespace WebServerAPI.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBook();

        public Task<BookModel> GetBook(int id);

        public Task<int> AddBook(BookModel book);

        public Task UpdateBook (int id, BookModel book);

        public Task DeleteBook(int id);
    }
}
