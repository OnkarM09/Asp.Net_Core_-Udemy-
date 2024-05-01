using revise.Models;

namespace Services
{
    public class BookService : IBookService
    {
        public int userId { get; set; }
        internal List<Book> books;

        public BookService()
        {
            userId = 555;
            books = new List<Book>()
        {
            new Book()
            {
                BookId = 1,
                Author = "Shantanu Shete"
            },
            new Book()
            {
                BookId = 2,
                Author = "Dixant Pal"
            },
             new Book()
            {
                BookId = 3,
                Author = "Akshay Wayalkar"
            },
        };
        }
        public List<Book> AllBooks()
        {
            return books;
        }
    }
}