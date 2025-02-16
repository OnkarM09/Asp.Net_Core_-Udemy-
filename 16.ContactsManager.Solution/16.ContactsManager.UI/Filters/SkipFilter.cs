using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters
{
    public class SkipFilter: Attribute, IFilterMetadata
    {
    }
}
