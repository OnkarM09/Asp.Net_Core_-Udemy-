using revise.Models;

namespace Services
{
    public class BookService : IBookService
    {
        public int userId { get; set; }
        internal List<Book> books;
        private readonly BooksDbContext _db;

        public BookService(BooksDbContext booksDbContext)
        {
            userId = 555;
            _db = booksDbContext;
        }
        public List<Book> AllBooks()
        {
            return _db.Books.ToList();
        }
    }
}