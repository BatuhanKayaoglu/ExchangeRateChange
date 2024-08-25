using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text;

namespace ExchangeRateConsumeService.Services
{
    public class ConsumeService
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly IHttpClientFactory httpClientFactory;

        public ConsumeService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("ExchangeRateChangeDbConnectionString");
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<bool> SendExchangeToClient(string data)
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44373/");
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("home/SignalToClient", content);
            if (!response.IsSuccessStatusCode)
                return false;

            return true;
        }

        // USING DAPPER FOR PERFORMANCE
        public async Task<bool> AddExchangeToDB(ExchangeRateReceiverEvent exchange)
        {
            using var connection = new SqlConnection(connectionString);
            decimal SellPrice = decimal.Parse(exchange.SellPrice.Replace(".", ""), CultureInfo.InvariantCulture);
            decimal newPrice = exchange.Price * SellPrice;

            await connection.ExecuteAsync("UPDATE [Product] SET ExchangeSellRate=@ExchangeSellRate, NewPrice=@NewPrice  WHERE Id=@Id ",
                                 new
                                 {
                                     Id = exchange.Id,
                                     ExchangeSellRate =SellPrice,
                                     NewPrice = newPrice
                                 });
            Console.WriteLine("Exchange data added to DB");
            return true;
        }
    }
}
