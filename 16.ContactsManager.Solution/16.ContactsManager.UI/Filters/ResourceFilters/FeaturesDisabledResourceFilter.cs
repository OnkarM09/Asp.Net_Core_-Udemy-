using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.ResourceFilters
{
    public class FeaturesDisabledResourceFilter : IAsyncResourceFilter
    {
        private readonly ILogger<FeaturesDisabledResourceFilter> _logger;
        private readonly bool _isDisabled;
        public FeaturesDisabledResourceFilter(ILogger<FeaturesDisabledResourceFilter> logger, bool disabled = true)
        {
            _logger = logger;
            _isDisabled = disabled;
        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            //Before logic
            _logger.LogInformation("{FilterName} : {Method} - before", nameof(FeaturesDisabledResourceFilter), nameof(OnResourceExecutionAsync));
            if (_isDisabled)
            {
             //   context.Result = new NotFoundResult();  //return 404
                context.Result = new StatusCodeResult(501);  //return 501
            }
            else
            {
                await next();
                //After logic
            }
            _logger.LogInformation("{FilterName} : {Method} - after", nameof(FeaturesDisabledResourceFilter), nameof(OnResourceExecutionAsync));
        }
    }
}
