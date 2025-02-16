using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.ActionFilters
{
    public class ResponseHeaderActionFilter : ActionFilterAttribute
    {
        private readonly string _key;
        private readonly string _value;

        public ResponseHeaderActionFilter( string key, string value, int order)
        {
            _key = key;
            _value = value;
            Order = order;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Response.Headers[_key] = _value;
            await next();  //Really important to add this for next action filter to execute (calls the subsequent action
        }
    }
}
