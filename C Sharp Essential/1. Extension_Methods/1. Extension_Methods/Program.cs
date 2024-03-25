using ClassLibrary1;
using _1._Extension_Methods;


Product p = new Product() { ProductCost = 1000, DiscountPercentage = 10};
Console.WriteLine(p.GetDiscount());  //This is an extension method
Console.ReadKey();