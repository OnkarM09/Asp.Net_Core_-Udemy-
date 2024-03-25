
using System.Collections.ObjectModel;

Dictionary<int, string> employees = new Dictionary<int, string>()
{
    {18,"Kohli" },
    {99, "Smith" },
    {7, "Dhoni" },
    {17, "deVilliers" }
};

//Looping through dictionary
foreach (KeyValuePair<int, string> employee in employees)
{
    Console.WriteLine(employee.Key + " " + employee.Value);
}

Console.WriteLine(employees[17]);

//Keys
Dictionary<int, string>.KeyCollection keys = employees.Keys;
foreach (int item in keys)
{
    Console.Write(item);
}

//Add key and value
//employees.Add(1, "Rahul");

//Remove collection 
employees.Remove(18);
foreach (KeyValuePair<int, string> employee in employees)
{
    Console.WriteLine(employee);
}

//Check if key exists
Console.WriteLine(employees.ContainsKey(18));

//Check if value exists
Console.WriteLine(employees.ContainsValue("Dhoni"));

//Clear
//employees.Clear();