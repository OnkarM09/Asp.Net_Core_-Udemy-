using _12._1_HTTP_client__StockApp_.Models;
using _12._1_HTTP_client__StockApp_.Services;
using Microsoft.AspNetCore.Mvc;

namespace _12._1_HTTP_client__StockApp_.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnhubService _myService;

        public HomeController(FinnhubService myService)
        {
            _myService = myService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string, object> stocks = await _myService.GetStockPriceQuote("MSFT");
            Stock stock = new Stock()
            {
                StockSymbol = "MSFT",
                CurrentPrice = Convert.ToDouble(stocks["c"].ToString()),
                HighestPrice = Convert.ToDouble(stocks["h"].ToString()),
                LowestPrice = Convert.ToDouble(stocks["l"].ToString()),
                OpenPrice = Convert.ToDouble(stocks["o"].ToString()),

            };
            return View(stock);
        }
    }
}
