using EksiSozluk.Common.Infrastructure;
using ExchangeRateChange.Common.RabbitMQ;
using System.Text.Json;

namespace ExchangeRateConsumeService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
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
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                })
                .StartingConsuming(QueueConstants.InstantCurrencyRateQueueName);
        }       
    }
}
