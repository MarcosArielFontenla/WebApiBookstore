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

        public List<Book> GetBooks()
        {
            return _books.Find(b => true).ToList();
        }

        public Book GetBookById(string id)
        {
            return _books.Find(b =>b.Id == id).First();
        }

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public Book UpdateBook(Book book)
        {
            GetBookById(book.Id);
            _books.ReplaceOne(b => b.Id == book.Id, book);
            return book;
        }

        public void DeleteBook(string id)
        {
            _books.DeleteOne(b => b.Id == id);
        }
    }
}
