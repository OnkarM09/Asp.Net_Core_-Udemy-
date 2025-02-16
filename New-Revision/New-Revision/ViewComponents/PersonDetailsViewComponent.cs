using Microsoft.AspNetCore.Mvc;
using New_Revision.Models;

namespace New_Revision.ViewComponents
{
    [ViewComponent]
    public class PersonDetailsViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Person p)
        {
            return View(p);
        }
    }
}
