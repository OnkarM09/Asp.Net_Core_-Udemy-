using _2.__Anonymus_Methods;
using System.Linq.Expressions;

Publisher p = new Publisher();
p.name = "Test";
//p.myEvent += delegate (int a, int b)
//{
//    Console.WriteLine(a + b);
//};

//better way to write using LambdaExpression  
p.myEvent += (a, b) =>
{
    Console.WriteLine(a + b);
};


Console.WriteLine(p.name);

//Invoke the raise event 
p.RaiseEvent(2, 3);
p.RaiseEvent(7, 3);
p.RaiseEvent(8, 3);