using ExchangeRateChange.Infrastructure.Context;
using ExchangeRateChange.Infrastructure.IRepositories;
using ExchangeRateChange.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ExchangeRateChange.API.Extensions.JwtConf;
using System.Reflection;
using System.Text;
using ExchangeRateChange.API.Services.Auth;
using ExchangeRateChange.API.Services.Token;
using ExchangeRateChange.API.Middlewares.ExceptionHandlerMiddleware;
using ExchangeRateChange.API.Middlewares.Filter.Validation;

namespace ExchangeRateChange.API.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddAPIRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthService, AuthService>();
            //services.AddTransient<ICompanyService, CompanyService>();
            //services.AddTransient<ITokenService, TokenService>();
            //services.AddTransient<IEmailSenderService, EmailSenderService>();
            //services.AddTransient<IEmployeeService, EmployeeService>();
            //services.AddTransient<IIssueService, IssueService>();
            //services.AddTransient<IProjectService, ProjectService>();
            //services.AddTransient<IReportService, ReportService>();

            // **** JWT CONFIGURATION START ****
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidAudience = JwtTokenDefaults.ValidAudience,
                    ValidIssuer = JwtTokenDefaults.ValidIssuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
                    ValidateIssuerSigningKey = true, // To verify whether the token value belongs to our application.
                    ValidateLifetime = true
                };

            });
            // **** JWT CONFIGURATION END ****

            // ****VALIDATION CONFIGURATION START ****  
            services.AddTransient<ExceptionMiddleware>();

            services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>();
            });
            // ****VALIDATION CONFIGURATION END ****  


            return services;

        }
    }
}
