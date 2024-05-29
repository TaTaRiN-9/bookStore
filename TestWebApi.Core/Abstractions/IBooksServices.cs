using TestWebApi.Core.Models;

namespace TestWebApi.Application.Services
{
    public interface IBooksServices
    {
        Task<int> CreateBook(Book book);
        Task<int> DeleteBook(int id);
        Task<List<Book>> GetAllBooks();
        Task<int> UpdateBook(int id, string title, string description, decimal price);
    }
}