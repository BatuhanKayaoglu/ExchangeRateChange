using AutoMapper;
using ExchangeRateChange.API.Services.Auth;
using ExchangeRateChange.API.Services.Token;
using ExchangeRateChange.Common.ViewModels;
using ExchangeRateChange.Entity.Models;
using ExchangeRateChange.Infrastructure.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateChange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService, IUnitOfWork uow, IMapper mapper) : ControllerBase
    {
        private readonly IProductService productService = productService;
        private readonly IUnitOfWork unitOfWork = uow;
        private readonly IMapper mapper = mapper;


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok();
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProduct()
        {
            return Ok();    
        }

    }
}
