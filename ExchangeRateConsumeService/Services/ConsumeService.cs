using Dapper;
using Microsoft.Data.SqlClient;
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
            //var client = new HttpClient();
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44373/");
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("home/signalr", content);
            if (!response.IsSuccessStatusCode)
                return false;

            return true;
        }

        public async Task<bool> AddExchangeToDB(ExchangeRateReceiverEvent exchange)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("UPDATE [Product] SET ExchangeSellRate=@ExchangeSellRate, NewPrice=@NewPrice  WHERE Id=@Id ",
                                 new
                                 {
                                     Id = exchange.Id,
                                     ExchangeSellRate = Convert.ToDecimal(exchange.SellPrice),
                                     NewPrice = exchange.Price * Convert.ToDecimal(exchange.SellPrice)
                                 });
            Console.WriteLine("Exchange added to DB");
            return true;
        }
    }
}
