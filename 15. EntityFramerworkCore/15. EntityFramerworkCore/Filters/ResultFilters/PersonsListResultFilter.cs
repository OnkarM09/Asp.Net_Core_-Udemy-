using Microsoft.AspNetCore.Mvc.Filters;

namespace _15._EntityFramerworkCore.Filters.ResultFilters
{
    public class PersonsListResultFilter : IAsyncResultFilter
    {
        private readonly ILogger<PersonsListResultFilter> _logger;
        public PersonsListResultFilter(ILogger<PersonsListResultFilter> logger)
        {
            _logger = logger;
        }
    
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            _logger.LogInformation("Executing Result Filter");
            await next();
            _logger.LogInformation("Executed Result Filter");
            context.HttpContext.Response.Headers["Last-Modified"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
