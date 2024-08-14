using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Infrastructure.IRepositories
{
    public interface IUnitOfWork
    {
        IExchangeRepository Exchange { get; }
        IProductRepository Product { get; }
        int SaveChanges();
    }
}
