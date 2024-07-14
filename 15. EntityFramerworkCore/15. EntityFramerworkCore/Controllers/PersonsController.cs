﻿using _15._EntityFramerworkCore.Filters;
using _15._EntityFramerworkCore.Filters.ActionFilters;
using _15._EntityFramerworkCore.Filters.AuthorizationFilters;
using _15._EntityFramerworkCore.Filters.ExceptionFilters;
using _15._EntityFramerworkCore.Filters.ResourceFilters;
using _15._EntityFramerworkCore.Filters.ResultFilters;
using _15._EntityFramerworkCore.Models;
using _15._EntityFramerworkCore.Services;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System.Reflection;

namespace _15._EntityFramerworkCore.Controllers
{
    //[TypeFilter(typeof(ResponseHeaderActionFilter), Arguments = new object[] { "my-controller-key", "my-controller-value", 3 })]  //Class level filter
 //   [TypeFilter(typeof(TokenResultFilter))]
  //  [TypeFilter(typeof(HandleExceptionFilter))]
  //  [TypeFilter(typeof(PersonsAlwaysRunResultFilter))]
  //  [SkipFilter]
    public class PersonsController : Controller
    {

        private readonly IPersonService _personService;
        private readonly IPersonAdderService _personAdderService;
        private readonly IPersonGetterService _personGetterService;

        public PersonsController(IPersonAdderService personAdderService, IPersonGetterService personGetterService)
        {
            _personAdderService = personAdderService;
            _personGetterService = personGetterService; 
        }

        [Route("/")]
        // [TypeFilter(typeof(ResponseHeaderActionFilter), Arguments = new object[] { "my-action-key", "my-action-value", 1 })]   // Arguments for action filter and Reusable (parameterized) filter  and action level filter
        //[ServiceFilter(typeof(PersonsListResultFilter))]
        [ResponseHeaderActionFilter("my-action-key", "my-action-value", 1)]
        public async Task<IActionResult> Index()
        {
            List<Person> persons = await _personGetterService.GetPersons();
            return View(persons);
        }

        [Route("[action]")]
        [HttpPost]
        [TypeFilter(typeof(FeaturesDisabledResourceFilter))]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            await _personAdderService.AddPersonToDb(person);
            return RedirectToAction("Index");
        }

        [Route("create/person")]
        public IActionResult CreatePersonForm()
        {
            return View();
        }

        [Route("[action]/{Id}")]
        //[TypeFilter(typeof(PersonsListActionFilter))] //This will create an object of personslistactionfilter and attach it to this action
       // [TypeFilter(typeof(TokenAutorizationFilter))]
        public async Task<IActionResult> EditPerson(int Id)
        {
            if (Id == null)
            {
                return Content("Person cannot be null");
            }
            Person p1 = await _personGetterService.GetPersonById(Id);
            return View(p1);
        }

        [Route("PersonsPDF")]
        public async Task<IActionResult> PersonsPDF()
        {
            //Get list of persons
            List<Person> persons = await _personGetterService.GetPersons();
            return new ViewAsPdf("PersonsPDF", persons, ViewData)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins()
                {
                    Top = 20,
                    Right = 20,
                    Bottom = 20,
                    Left = 20
                },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
        }

        [Route("PersonsCSV")]
        public async Task<IActionResult> PersonsCSV()
        {
            MemoryStream memoryStream = await _personGetterService.GerPersonCSV();
            return File(memoryStream, "application/octet-stream", "persons.csv");
        }

        [Route("PersonsExcel")]
        public async Task<IActionResult> PersonsExcel()
        {
            MemoryStream memoryStream = await _personGetterService.GerPersonExcel();
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "persons.xlsx");
        }
    }
}
