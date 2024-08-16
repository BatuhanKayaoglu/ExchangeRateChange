using ExchangeRateChange.Common.ViewModels;
using ExchangeRateChange.Entity.Models;
using ExchangeRateChange.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExchangeRateChange.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient(); 
            client.BaseAddress = new Uri("https://localhost:44308/api/Exchange/"); 
            HttpResponseMessage response = await client.GetAsync("get-exchange-products");

            var responseData = await response.Content.ReadAsStringAsync(); 
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<GetProductListVM>? products = JsonSerializer.Deserialize<List<GetProductListVM>>(responseData, options);
            return View(products);
        }

        public async Task<IActionResult> sendProductData(AddExchangeProductVM addExchangeProduct)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44308/api/Exchange/add-exchange-product";
                StringContent jsonContent = new StringContent(JsonSerializer.Serialize(addExchangeProduct), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    Product? product = JsonSerializer.Deserialize<Product>(responseData, options);

                    return Ok(product);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }
    }
}
