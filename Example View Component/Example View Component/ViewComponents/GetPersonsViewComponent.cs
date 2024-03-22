using Example_View_Component.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example_View_Component.ViewComponents
{
    [ViewComponent]
    public class GetPersonsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<Person> persons)
        {
            return View(persons);
        }
    }
}
