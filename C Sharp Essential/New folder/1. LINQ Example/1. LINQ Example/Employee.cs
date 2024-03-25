using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._LINQ_Example
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public string? Job { get; set; }
        public string? City { get; set; }

        public double Salary { get; set; }
    }

    public class Person
    {
        public string PersonName { get; set; }
    }
}
