using System.Collections.Generic;
using System.Linq;
using books_api.Model;

namespace books_api.Services.Impl
{
    public class BookService : IBookService
    {
        private readonly BooksContext context;

        public BookService(BooksContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return context.Books.SingleOrDefault(b => b.Id == id);
        }

        public Book DeleteBook(int id)
        {
            var book = context.Books.SingleOrDefault(b => b.Id == id);

            if(book != null)
                context.Books.Remove(book);
                
            context.SaveChanges();
            return book;
        }
    }
}