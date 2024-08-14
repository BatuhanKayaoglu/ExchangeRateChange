using ExchangeRateChange.Entity.Models;
using ExchangeRateChange.Infrastructure.Context;
using ExchangeRateChange.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Infrastructure.Repositories
{
    public class ExchangeRepository : GenericRepository<Exchange>, IExchangeRepository
    {
        public ExchangeRepository(ExchangeRateChangeContext dbContext) : base(dbContext)
        {
        }
    }
}
