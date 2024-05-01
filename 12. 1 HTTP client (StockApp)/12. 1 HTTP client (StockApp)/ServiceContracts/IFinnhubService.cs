namespace _12._1_HTTP_client__StockApp_.ServiceContracts
{
    public interface IFinnhubService
    {
       Task <Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol); 
    }
}
