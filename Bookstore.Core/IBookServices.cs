using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface IBookServices
    {
        List<Book> GetBooks();
        Book GetBookById(string id);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        void DeleteBook(string id);
    }
}
