using AutoMapper;
using Azure.Core;
using EksiSozluk.Common.Infrastructure;
using ExchangeRateChange.API.Services.Auth;
using ExchangeRateChange.API.Services.Token;
using ExchangeRateChange.Common.Events;
using ExchangeRateChange.Common.RabbitMQ;
using ExchangeRateChange.Common.ViewModels;
using ExchangeRateChange.Entity.Models;
using ExchangeRateChange.Infrastructure.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateChange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController(IExchangeService exchangeService, IUnitOfWork uow, IMapper mapper) : ControllerBase
    {
        private readonly IExchangeService exchangeService = exchangeService;
        private readonly IUnitOfWork unitOfWork = uow;
        private readonly IMapper mapper = mapper;


        [HttpGet]
        [Route("get-exchange-products")]
        public async Task<IActionResult> GetExchangeProducts()
        {
            List<Product> products = await unitOfWork.Product.GetAll();
            List<GetProductListVM> data = mapper.Map<List<GetProductListVM>>(products);
            return Ok(data);
        }

        [HttpPost]
        [Route("add-exchange-product")]
        public async Task<IActionResult> AddExchangeProduct(AddExchangeProductVM addExchangeProduct)
        {
            Product prod = await unitOfWork.Product.AddAsyncToProduct(addExchangeProduct);

            // RabbitMQ push exchange event 
            QueueFactory.SendMessageToExchange(exchangeName: QueueConstants.ExchangeRateExchangeName,
                exchangeType: QueueConstants.DefaultExchangeType,
                queueName: QueueConstants.CreateExchangeRateQueueName,
             obj: new CreateExchangeEvent()
             {
                 Id = prod.Id,
                 Price = prod.Price,
                 ExchangeType = addExchangeProduct.ExchangeType,
             });

            return Ok(prod);
        }

    }
}
