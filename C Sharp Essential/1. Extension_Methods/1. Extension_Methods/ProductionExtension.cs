using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._Extension_Methods
{
    public static class ProductionExtension  //For extension method the class must be static (also method too)
    {
        //Extension method for product class
        public static double GetDiscount(this Product product)   //here this means that the current method is not a normal static method, Instead it's an extension method and second word is a Class name where we want to use this extension method and third word is a argument
        {
          return  product.ProductCost * product.DiscountPercentage /100;
        }
        //This method is static but for the Product class its an instance method i.e. Object method.
    }
}
