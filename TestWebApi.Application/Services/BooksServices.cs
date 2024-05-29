using TestWebApi.Core.Models;
using TestWebApi.DataAccess.Repository;

// бизнес логика соединяет нашу базу данных с контроллерами.
namespace TestWebApi.Application.Services
{
    public class BooksServices : IBooksServices
    {
        private readonly IBookRepository _bookRepository;
        public BooksServices(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.Get();
        }

        public async Task<int> CreateBook(Book book)
        {
            return await _bookRepository.Create(book);
        }

        public async Task<int> UpdateBook(int id, string title, string description, decimal price)
        {
            return await _bookRepository.Update(id, title, description, price);
        }

        public async Task<int> DeleteBook(int id)
        {
            return await _bookRepository.Delete(id);
        }
    }
}
