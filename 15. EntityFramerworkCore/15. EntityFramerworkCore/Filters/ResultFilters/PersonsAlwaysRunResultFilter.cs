﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace _15._EntityFramerworkCore.Filters.ResultFilters
{
    public class PersonsAlwaysRunResultFilter : IAlwaysRunResultFilter
    {
        private readonly ILogger<PersonsAlwaysRunResultFilter> _logger;
        public PersonsAlwaysRunResultFilter(ILogger<PersonsAlwaysRunResultFilter> logger)
        {
            _logger = logger;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
           
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
         if(context.Filters.OfType<SkipFilter>().Any())
            {
                return;
            } 
        }
    }
}
