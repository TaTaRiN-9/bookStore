using TestWebApi.Core.Models;

namespace TestWebApi.DataAccess.Repository
{
    public interface IBookRepository
    {
        Task<int> Create(Book book);
        Task<int> Delete(int id);
        Task<List<Book>> Get();
        Task<int> Update(int id, string title, string description, decimal price);
    }
}