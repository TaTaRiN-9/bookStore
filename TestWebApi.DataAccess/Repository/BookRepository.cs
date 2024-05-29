using Microsoft.EntityFrameworkCore;
using TestWebApi.Core.Models;
using TestWebApi.DataAccess.Entities;

namespace TestWebApi.DataAccess.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly TestWebApiDbContext _db;
        public BookRepository(TestWebApiDbContext db)
        {
            _db = db;
        }

        private int GetId()
        {
            return _db.books.ToList().Last().Id;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _db.books
                .AsNoTracking()
                .ToListAsync();

            List<Book> books = bookEntities
                .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).book).ToList();

            return books;
        }

        public async Task<int> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Title = book.Title,
                Description = book.Description,
                Price = book.Price
            };

            await _db.books.AddAsync(bookEntity);
            await _db.SaveChangesAsync();

            bookEntity.Id = GetId();

            return bookEntity.Id;
        }

        // костыльный метод
        public async Task<int> Update(int id, string title, string description, decimal price)
        {
            var book = await _db.books.Where(b => b.Id == id).ToListAsync();
            book[0].Title = title;
            book[0].Description = description;
            book[0].Price = price;
            await _db.SaveChangesAsync();
            return id;
        }

        // костыльный метод
        public async Task<int> Delete(int id)
        {
            var book = _db.books.Where(b => b.Id == id).ToList()[0];
            _db.books.Remove(book);
            await _db.SaveChangesAsync();
            return id;
        }
    }
}
