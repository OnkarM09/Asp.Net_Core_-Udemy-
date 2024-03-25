class Employee
{

    public int x { get; set; }
}

class EmployeeBusinessLogic
{
    public Employee? GetEmployee()
    {
        //return new Employee() { x = 10 };
        return null;
    }
}

class Program
{
    static void Main()
    {
        EmployeeBusinessLogic e1 = new EmployeeBusinessLogic();
        Employee? employee = e1.GetEmployee();  //Null is reached here
        if (employee != null) //Preventing accepting null values
        {
            Console.WriteLine(employee.x);
        }
    }
}

//Employee = non nullable(null values are not accepted)
//Employee? = nullable