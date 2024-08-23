using EksiSozluk.Common.Infrastructure;
using ExchangeRateChange.Common.Hubs;
using ExchangeRateChange.Common.RabbitMQ;
using ExchangeRateChange.Common.ViewModels;
using ExchangeRateConsumeService.Services;
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
        private readonly ConsumeService consumeService;



        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory, ConsumeService consumeService)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            this.httpClientFactory = httpClientFactory;
            this.consumeService = consumeService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(QueueConstants.ExchangeRateExchangeName)
                .EnsureQueue(QueueConstants.InstantCurrencyRateQueueName, QueueConstants.ExchangeRateExchangeName)
                .Receive<ExchangeRateReceiverEvent>(async (fav) =>
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        AllowTrailingCommas = true,
                        IgnoreNullValues = true,
                    };

                    string data = JsonSerializer.Serialize(fav, options);

                    bool control = await consumeService.SendExchangeToClient(data);
                    if (control)
                        await consumeService.AddExchangeToDB(fav); 
                    //await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Test", data);
                })
            .StartingConsuming(QueueConstants.InstantCurrencyRateQueueName);
        }
    }
}
