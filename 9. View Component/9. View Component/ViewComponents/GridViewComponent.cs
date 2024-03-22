using Microsoft.AspNetCore.Mvc;
using _9._View_Component.Models;

namespace _9._View_Component.ViewComponents
{
    [ViewComponent] //Either this or suffix class with ViewComponent 
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PersonGrid grid)
        {
            /*PersonGrid PersonGrid = new PersonGrid()
            {
                GridTitle = "Persons List",
                Persons = new List<Person>
                {
                    new Person()
                    {
                        PersonName = "John Wick",
                        JobTitle = "Professional Killer"
                    },
                      new Person()
                    {
                        PersonName = "Uchiha Obito",
                        JobTitle = "Hokage"
                    }
                }
            };
            ViewData["Grid"] = PersonGrid;*/
            return View(grid);  //Not a regular view but a partial view location: Views/Shared/ViewComponent/Grid/Default.cshtml
        }
    }
}
