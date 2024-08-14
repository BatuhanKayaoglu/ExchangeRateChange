using Azure.Core;
using EksiSozluk.Common.Infrastructure;
using ExchangeRateChange.API.Services.Auth;
using ExchangeRateChange.API.Services.Token;
using ExchangeRateChange.Common.Events;
using ExchangeRateChange.Common.RabbitMQ;
using ExchangeRateChange.Infrastructure.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateChange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController(IExchangeService exchangeService, IUnitOfWork uow) : ControllerBase
    {
        private readonly IExchangeService exchangeService = exchangeService;
        private readonly IUnitOfWork unitOfWork = uow;


        [HttpPost]
        [Route("add-exchange-rate")]    
        public async Task<IActionResult> AddExchangeRate()
        {
            QueueFactory.SendMessageToExchange(exchangeName: QueueConstants.ExchangeRateExchangeName,
               exchangeType: QueueConstants.DefaultExchangeType,
               queueName: QueueConstants.CreateExchangeRateQueueName,
            obj: new CreateExchangeEvent()
            {
                Id = Guid.NewGuid(),
                Price = 10,
                Name = "USD",
                ExchageType = "USD",
                ExchangeName = "USD"    
               });

            return Ok();
        }       

    }
}
