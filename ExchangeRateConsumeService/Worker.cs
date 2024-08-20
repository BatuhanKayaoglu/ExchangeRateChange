using EksiSozluk.Common.Infrastructure;
using ExchangeRateChange.Common.Hubs;
using ExchangeRateChange.Common.RabbitMQ;
using ExchangeRateChange.Common.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ExchangeRateConsumeService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpClientFactory httpClientFactory;



        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            this.httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(QueueConstants.ExchangeRateExchangeName)
                .EnsureQueue(QueueConstants.InstantCurrencyRateQueueName, QueueConstants.ExchangeRateExchangeName)
                .Receive<ExchangeRateReceiverEvent>(async (fav) =>
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        AllowTrailingCommas = true,
                        IgnoreNullValues = true,
                    };

                    var data = JsonSerializer.Serialize(fav, options);

                    var client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44373/");
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("home/signalr", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Success: {responseBody}");
                    }

                    //var hubContext = _serviceProvider.GetRequiredService<IHubContext<ExchangeRateHub>>();
                    //await hubContext.Clients.All.SendAsync("ReceiveMessage", "dataaa");
                    //await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Test", data);


                })
            .StartingConsuming(QueueConstants.InstantCurrencyRateQueueName);
        }
    }
}
