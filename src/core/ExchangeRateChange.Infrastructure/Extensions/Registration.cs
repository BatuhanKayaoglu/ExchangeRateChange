using ExchangeRateChange.Infrastructure.Context;
using ExchangeRateChange.Infrastructure.IRepositories;
using ExchangeRateChange.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ExchangeRateChange.Entity.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Infrastructure.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExchangeRateChangeContext>(conf =>
            {
                var connStr = configuration["ExchangeRateChangeDbConnectionString"].ToString();
                conf.UseSqlServer(connStr);
            });

            var assm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assm);
            services.AddFluentValidation(p => p.RegisterValidatorsFromAssembly(assm)); // FOR FLUENT VALIDATION 


            services.AddIdentity<AppUser, AppRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<ExchangeRateChangeContext>(); // Identity'yi ekledik.   

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IExchangeRepository, ExchangeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;

        }
    }
}
