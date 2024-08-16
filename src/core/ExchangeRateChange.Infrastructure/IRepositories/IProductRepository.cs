using ExchangeRateChange.Common.ViewModels;
using ExchangeRateChange.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Infrastructure.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> AddAsyncToProduct(AddExchangeProductVM entity);
    }
}
