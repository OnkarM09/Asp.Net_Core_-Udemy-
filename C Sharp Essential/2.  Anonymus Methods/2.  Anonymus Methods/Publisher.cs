using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void MyDelegateType(int a, int b);

namespace _2.__Anonymus_Methods
{
    public class Publisher
    {
        public string? name {  get; set; }

        //step1 create event 
        public event MyDelegateType myEvent;

        //step 2 raise event 
        public void RaiseEvent(int a, int b)
        {
            if(this.myEvent != null)
            {
                this.myEvent(a, b);
            }
        }
    }
}
