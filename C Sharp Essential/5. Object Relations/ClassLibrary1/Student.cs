namespace College
{
    public class Student
    {
        public int RollNo { get; set; }

        public string? StudentName { get; set; }

        public string? Email { get; set; }

        public Branch Branch { get; set; }  //Contains reference to the branch class 

        public List<Examination> exams {  get; set; }
    }
}