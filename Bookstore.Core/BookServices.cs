using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book> _books;

        public BookServices(IDbClient dbClient)
        {
            _books = dbClient.GetBooksCollection();
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _books.Find(b => true).ToListAsync();
        }

        public async Task<Book> GetBookById(string id)
        {
            return await _books.Find(b =>b.Id == id).FirstAsync();
        }

        public async Task<Book> AddBook(Book book)
        {
            await _books.InsertOneAsync(book);
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            await GetBookById(book.Id);
            await _books.ReplaceOneAsync(b => b.Id == book.Id, book);
            return book;
        }

        public async Task DeleteBook(string id)
        {
            await _books.DeleteOneAsync(b => b.Id == id);
        }
    }
}
