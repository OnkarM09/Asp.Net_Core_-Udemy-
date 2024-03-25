using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._Interfaces
{
    public class Manager : IEmployee
    {
        public string Name { get; set; }

        public void GetEmployeeName()
        {
           Console.WriteLine(this.Name);
        }
    }
}
