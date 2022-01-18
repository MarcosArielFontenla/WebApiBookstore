using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface IBookServices
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBookById(string id);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task DeleteBook(string id);
    }
}
