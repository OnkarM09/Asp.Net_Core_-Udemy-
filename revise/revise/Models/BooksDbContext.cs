using Microsoft.EntityFrameworkCore;
namespace revise.Models
{
    public class BooksDbContext : DbContext
    {

        public BooksDbContext(DbContextOptions optoins) : base(optoins) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().ToTable("Books");

            string booksjson = System.IO.File.ReadAllText("books.json");

            List <Book> books = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(booksjson); 
            
            foreach (Book book in books)
            {
                modelBuilder.Entity<Book>().HasData(book);
            }
           
        }
    }
}
