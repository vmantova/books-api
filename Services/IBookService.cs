using System.Collections.Generic;
using books_api.Model;

namespace books_api.Services
{
    public interface IBookService
    {
         IEnumerable<Book> GetAllBooks();
         Book GetBookById(int id);
         void  AddBook(Book book);
         Book DeleteBook(int id);
    }
}