using _15._EntityFramerworkCore.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using OfficeOpenXml.Drawing.Chart.ChartEx;

namespace _15._EntityFramerworkCore.Filters.ActionFilters
{
    public class PersonsListActionFilter : IActionFilter
    {
        private readonly ILogger<PersonsListActionFilter> _logger;

        public PersonsListActionFilter(ILogger<PersonsListActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Add before logic
            _logger.LogInformation("PresonsListActionOnActionExecuted");
            PersonsController personController = (PersonsController)context.Controller;
            IDictionary<string, object?>? paramters = (IDictionary<string, object?>?)context.HttpContext.Items["arguements"];
            if (paramters != null)
            {
                if (paramters.ContainsKey("id"))
                {
                    personController.ViewData["TestAction"] = paramters["id"];
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["arguements"] = context.ActionArguments;
            //Add before logic
            _logger.LogInformation("PresonsListActionOnActionExecuting");
            if (context.ActionArguments.ContainsKey("id"))
            {
                string? person = Convert.ToString(context.ActionArguments["id"]);
                _logger.LogInformation("person is {person}", person);
            }
        }
    }
}
