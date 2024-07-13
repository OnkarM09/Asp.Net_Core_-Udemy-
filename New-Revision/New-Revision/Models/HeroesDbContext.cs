using Microsoft.EntityFrameworkCore;

namespace New_Revision.Models
{
    public class HeroesDbContext : DbContext
    {

        public HeroesDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hero>().ToTable("Heroes");
            modelBuilder.Entity<Movie>().ToTable("Movies");

            modelBuilder.Entity<Hero>().HasData(new Hero()
            {
                Id = 1,
                Name = "Ironman",
                Power = "Rich",
                Rank = 1
            });

            modelBuilder.Entity<Movie>().HasData(new Movie() { 
                MovieId = 1,
                Title = "Ironman"
            });
        }
    }
}
