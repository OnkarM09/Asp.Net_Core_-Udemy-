namespace _15._EntityFramerworkCore.Models;

using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class PersonsDbContext : DbContext
{
    public PersonsDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<JobDetails> JobDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Person>().ToTable("Persons");
        modelBuilder.Entity<JobDetails>().ToTable("JobDetails");

        //Seed data
        /*   modelBuilder.Entity<Person>().HasData(new Person()
           {
               Id = 5,
               Name = "Shinchan",
               Age = 8,
               BirthDate = Convert.ToDateTime("01-01-2016"),
               Email = "shinchan@hungama.com"
           });*/
        //or read json file
        string personJson = System.IO.File.ReadAllText("persons.json");
        List<Person> persons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(personJson);

        foreach (Person person in persons)
        {
            modelBuilder.Entity<Person>().HasData(person);
        }

        string JobDetails = System.IO.File.ReadAllText("job-details.json");
        List<JobDetails> jobs = System.Text.Json.JsonSerializer.Deserialize<List<JobDetails>>(JobDetails);

        foreach (JobDetails job in jobs)
        {
            modelBuilder.Entity<JobDetails>().HasData(job);
        }

        //Fluent API
        modelBuilder.Entity<Person>().Property(temp => temp.Gender)
            .HasColumnName("PersonGender")   //changed the column name from Gender to PersonGender
            .HasColumnType("varchar(8)")      // changed the column data type from nvarchar to varchar
            .HasColumnType("Male");         //Default value for PersonGender column

        //  modelBuilder.Entity<Person>().HasIndex(temp => temp.Email).IsUnique();    //No duplicate emails
        modelBuilder.Entity<Person>().HasCheckConstraint("CHK_Email", "len(email) > 5");


        //Table relations using Fluent API
        /*modelBuilder.Entity<Person>(entity =>
        {
            entity.HasOne<JobDetails>(p => p.JobDetails)
            .WithMany(p => p.Persons)
            .HasForeignKey(p => p.JobTitle);
        });*/
    }
    public List<Person> _spGetAllPersons()
    {
        return Persons.FromSqlRaw("EXECUTE [dbo].[GetAllPersons]").ToList();
    }

    public int sp_InsertPerson(Person person)
    {
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@Name", person.Name),
            new SqlParameter("@Email", person.Email),
            new SqlParameter("@Age", person.Age),
            new SqlParameter("@BirthDate", person.BirthDate),
        };

        return Database.ExecuteSqlRaw("EXECUTE [dbo].[InsertPerson] @Name, @Email, @Age, @BirthDate", parameters);
    }
}
