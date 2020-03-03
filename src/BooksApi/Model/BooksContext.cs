using Microsoft.EntityFrameworkCore;

namespace books_api.Model
{
    public class BooksContext : DbContext
    {
        public BooksContext()
        {
            
        }
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }
    }
}