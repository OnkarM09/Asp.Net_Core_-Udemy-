using _12._1_HTTP_client__StockApp_.ServiceContracts;
using System.Text.Json;

namespace _12._1_HTTP_client__StockApp_.Services
{
    public class FinnhubService : IFinnhubService
    {
        private IHttpClientFactory _httpClientFactory;
        public FinnhubService(IHttpClientFactory httpClientFactory) { 
            _httpClientFactory = httpClientFactory;
        }


        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            using (HttpClient httpClient= _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token=co220u1r01qvggedq7agco220u1r01qvggedq7b0"),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);

                string response = streamReader.ReadToEnd();
                
                Dictionary<string, object> responseDictionary = JsonSerializer.Deserialize<Dictionary<string,object>>(response);
                if(response == null)
                {
                    throw new InvalidCastException("No response from finnhub service");
                }
                if (responseDictionary.ContainsKey("error"))
                {
                    throw new InvalidCastException("Some error occured form finnhub service");
                }
                return responseDictionary;
            }
        }
    }
}
