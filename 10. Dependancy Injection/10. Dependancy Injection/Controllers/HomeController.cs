using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;
using Autofac;

namespace _10._Dependancy_Injection.Controllers
{
    public class HomeController : Controller
    {
        //private readonly CitiesService _citiesService;
        private readonly ICitiesService _citiesService;
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        //private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILifetimeScope _serviceProvider;   //Using Autofac
        public HomeController(ICitiesService citiesService,
            ICitiesService citiesService1,
            ICitiesService citiesService2,
            IServiceScopeFactory serviceScopeFactory,//Calling service in constructor called as constructor injection
            ILifetimeScope serviceProvider
            ) 
        {
            //Creating object of citiesService class
            //_citiesService = new CitiesService();
            //This is a bad practice as high level module like controllers have dependancy on low level modules like services 
            _citiesService = citiesService;
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            //_serviceScopeFactory = serviceScopeFactory;
            _serviceProvider = serviceProvider;
        }

        [Route("/")]
        public IActionResult Index()  // [FromServices] ICitiesService _citiesService//Method injection
        {
            List<string> cities = _citiesService.GetCities();
            ViewBag.InstanceId1 = _citiesService.ServiceInstanceId;
            ViewBag.InstanceId2 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId3 = _citiesService2.ServiceInstanceId;

            //using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            using (ILifetimeScope scope = _serviceProvider.BeginLifetimeScope())
            {
                //Injected cities service
                //Created new cities service object
                //ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>(); //This is equivalent to calling the service above like in constructor
                ICitiesService citiesService = scope.Resolve<ICitiesService>();
                ViewBag.InstanceIdCitieServiceScope = citiesService.ServiceInstanceId;
                //End of the life time of the scope and it will call dispose automatically.
            }

            return View(cities);
        }
    }
}
