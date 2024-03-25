
using College;

Student s1 = new Student();

s1.StudentName = "Maverick";
s1.RollNo = 1;
s1.Email = "maverick@topgun.com";

Branch b1 = new Branch();
b1.BranchName = "Air Force";
b1.NoOfSem = 6;

//This is called one to one relationship
s1.Branch = b1;

Examination e1 = new Examination();
e1.ExamName = "Air Force";
e1.Month = 2;
e1.Year = 2023;
e1.MaxMarks = 100;
e1.SecuredMarks = 100;
Examination e2 = new Examination();
e2.ExamName = "Navy";
e2.Month = 3;
e2.Year = 2021;
e2.MaxMarks = 100;
e2.SecuredMarks = 90;

//This is called one to Many relationship
s1.exams = new List<Examination>();
s1.exams.Add(e1);
s1.exams.Add(e2);

Student s2 = new Student();
s2.StudentName = "Naruto";
s2.RollNo = 2;
s2.Email = "uzumakinaruto@hokage.com";

//This is called as many to one relationship
//Here branch is only one which is air force but its used by 2 students of the the same class 
s2.Branch = b1;


Console.WriteLine(s1.StudentName);
Console.WriteLine(s1.RollNo);
Console.WriteLine(s1.Email);
Console.WriteLine(s1.Branch.BranchName);
Console.WriteLine(s1.Branch.NoOfSem);
foreach(Examination e  in s1.exams)
{   
Console.WriteLine(e.ExamName);
}

Console.WriteLine(s2.StudentName);
Console.WriteLine(s2.RollNo);
Console.WriteLine(s2.Email);
Console.WriteLine(s2.Branch.BranchName);
Console.WriteLine(s2.Branch.NoOfSem);