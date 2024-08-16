using AutoMapper;
using ExchangeRateChange.Common.ViewModels;
using ExchangeRateChange.Entity.Models;
using ExchangeRateChange.Infrastructure.Context;
using ExchangeRateChange.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ExchangeRateChangeContext dbContext;  
        private readonly IMapper mapper;
        public ProductRepository(ExchangeRateChangeContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext; 
        }

        public virtual async Task<Product> AddAsyncToProduct(AddExchangeProductVM entity)
        {
            Product mappedProduct = mapper.Map<Product>(entity);
            await dbContext.AddAsync(mappedProduct); 
            return mappedProduct;   
        }
    }
}
