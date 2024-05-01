using _1._LINQ_Example;

List<Employee> employees = new List<Employee>()
{
    new Employee{ EmpId = 1, EmpName = "John Wick", Job = "Killer", City = "New York", Salary = 999},
    new Employee { EmpId = 2, EmpName = "Virat Kohli", Job = "Cricketer", City = "New Delhi",  Salary = 129},
    new Employee { EmpId = 3, EmpName = "Chrisitano Ronaldo", Job = "Footballer", City = "Real Madrid", Salary = 456},
    new Employee { EmpId = 4, EmpName = "Steve Smmith", Job = "Cricketer", City = "Sydney", Salary = 234},
    new Employee { EmpId = 5, EmpName = "Klaus", Job = "COC Player", City = "Seoul", Salary = 49},
};

//var Cricketer =  employees.Where(employee => employee.Job == "Cricketer");
IEnumerable<Employee> Cricketer = employees.Where(employee => employee.Job == "Cricketer");

//foreach(Employee e in Cricketer)
//{
//    Console.WriteLine($"{e.EmpName} {e.Job} lives in {e.City}");
//}

//Order BY
//IOrderedEnumerable<Employee> orderedEmployees = employees.OrderBy(employee => employee.Job); 
IOrderedEnumerable<Employee> orderedEmployees = employees.OrderBy(employee => employee.Job)  //If job has multiple entries for ex here cricketer then in that we want to order by employee name
    .ThenBy(e => e.EmpName);  //It will only consider if job is same for multiple entries then only it will sort that with employee name
//You can also add more .ThenBy as much as you would like,
//ThenByDescending for descending order

//Order by descending
//IOrderedEnumerable<Employee> orderedEmployees = employees.OrderByDescending(employee => employee.Salary);

//foreach (Employee e in orderedEmployees)
//{
//    Console.WriteLine($"{e.EmpName} {e.Job} {e.City} {e.EmpId} {e.Salary}");
//}


//First or FirstOrDefault
List<Employee> Cricks = employees.Where(e => e.Job == "Cricketer").ToList();
//This will return 2 rows as we have two criceters objects ,
//To get only one object or entry we use First or FirstOrDefault
//Without First 
//Console.WriteLine(Cricks[0].EmpName);

//Using First
//Employee firstCricketer = employees.First(e => e.Job == "Cricketer");
//Console.WriteLine(firstCricketer.EmpName);

//Problem with first is if no matching record is found then it will break the application so instead use FirstOrDefault.
Employee firstCrick = employees.FirstOrDefault(e => e.Job == "Cricketery");
//Here it will assign null if no record is found
//SO we need to check if value is not null to avoid application break

if (firstCrick != null)
{
    Console.WriteLine(firstCrick.EmpName);
}
else
{
    Console.WriteLine("No record found!");
}

//Last or LastOrDefault is same but gives us last element which mathches with the condition

//To get element at the specific index use ElementAt()
Employee atIndex = employees.Where(e => e.Job == "Cricketer").ElementAt(1);
Console.WriteLine($"At 1 Index {atIndex.EmpName}");

//Again element at has the same drawback as First or last 
//So use ElementAtOrDefault()

Employee atIndexOrDefault = employees.Where(e => e.Job == "Cricketer").ElementAtOrDefault(0);
if (atIndexOrDefault != null)
{

    Console.WriteLine($"At 0 Index or Default {atIndexOrDefault.EmpName}");
}
else
{
    Console.WriteLine("No record found!");
}

//Single or SingleOrDefault
//These are almost identical to the First or FirstOrDefault
//So what is difference? 
//In our list of objects we have two objects with job = Cricketer
//If we use the condition for find Single with job == cricketer then it will throw error 
//This is the difference between first and single
//For example
Employee singleEmp = employees.Single(e => e.Job == "Killer");
//Employee singleEmp = employees.Single(e => e.Job == "Cricketers"); // This won't work becuase it will have more than one matched element
Console.WriteLine(singleEmp.EmpName);

//Again this has same drawback as First and Last So we will use SingleOrDefault 

Employee singleOrDefault = employees.SingleOrDefault(e => e.Job == "Footballer");
//Check if value is not null
if (singleOrDefault != null)
{
    Console.WriteLine(singleOrDefault.EmpName);
}
else
{
    Console.WriteLine("no record found for single");
}
//So single or singleordefault is used when only one matched element is there


//Select
List<Person> selectedData = employees.Select(e => new Person() { PersonName = e.EmpName }).ToList();
Console.WriteLine("Select statement.");
foreach (var item in selectedData)
{
    Console.WriteLine(item.PersonName);
}

//Min and Max
double minEmpSalary = employees.Min(e => e.Salary);
double maxEmpSalary = employees.Max(e => e.Salary);
double sumEmpSalary = employees.Sum(e => e.Salary);
double avgEmpSalary = employees.Average(e => e.Salary);
double countEmpSalary = employees.Count();

Console.WriteLine(minEmpSalary);
Console.WriteLine(maxEmpSalary);
Console.WriteLine(sumEmpSalary);
Console.WriteLine(avgEmpSalary);
Console.WriteLine(countEmpSalary);

