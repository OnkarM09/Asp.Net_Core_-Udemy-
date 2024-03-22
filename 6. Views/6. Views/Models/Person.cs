namespace _6._Views.Models
{
    public class Person
    {
        public string? name { get; set; }
        public DateTime dateofbirth { get; set; }

        public Gender genderType { get; set; }
    }

    public enum Gender
    {
        Male, Female, Other
    }
}
