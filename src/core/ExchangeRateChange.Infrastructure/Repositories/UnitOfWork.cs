using ExchangeRateChange.Infrastructure.Context;
using ExchangeRateChange.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using ExchangeRateChange.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ExchangeRateChange.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExchangeRateChangeContext _context;
        private readonly IMapper mapper;    

        public UnitOfWork(ExchangeRateChangeContext context,IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(DbContext));
            Product = new ProductRepository(_context,mapper);
 
        }

        public IProductRepository Product { get; private set; }

        public int SaveChanges() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();


    }
}
