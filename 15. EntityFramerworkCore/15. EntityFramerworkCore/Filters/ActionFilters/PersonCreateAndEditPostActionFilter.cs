using _15._EntityFramerworkCore.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _15._EntityFramerworkCore.Filters.ActionFilters
{
    public class PersonCreateAndEditPostActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Before logic here
            if (context.Controller is PersonsController personsController)
            {
                if (!personsController.ModelState.IsValid)
                {
                    personsController.ViewBag.Errors = personsController.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                   // var personCreateRequest = context.ActionArguments["person"];
                    context.Result = personsController.RedirectToAction("Index");   //If we assign anything to the result then it will shor circuit(means it wil not call awiat next())
                }
            }
            else
            {
                await next();
            }
            //After logic here
        }
    }
}
