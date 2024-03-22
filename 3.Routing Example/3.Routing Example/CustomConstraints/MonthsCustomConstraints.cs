using System.Text.RegularExpressions;

namespace _3.Routing_Example.CustomConstraints
{
    public class MonthsCustomConstraints : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //check if the value exists
            if(!values.ContainsKey(routeKey))
            {
                return false;
            }
            Regex regex = new Regex("^(sep|oct|nov|dec)$");
            string? monthVal = Convert.ToString(values[routeKey]);
            if(regex.IsMatch(monthVal))
            {
                return true;
            }
            return false;
        }
    }
}
