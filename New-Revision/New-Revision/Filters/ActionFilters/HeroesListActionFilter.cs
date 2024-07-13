using Microsoft.AspNetCore.Mvc.Filters;

namespace New_Revision.Filters.ActionFilters
{
    public class HeroesListActionFilter : IActionFilter
    {
        private readonly ILogger<HeroesListActionFilter> _logger;
        public HeroesListActionFilter(ILogger<HeroesListActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("This is on action executed");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("This is on action execting");
        }
    }
}
