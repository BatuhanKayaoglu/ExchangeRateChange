using ExchangeRateConsumeService;
using ExchangeRateConsumeService.Services;
using Microsoft.AspNetCore.SignalR;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Services.AddHttpClient();   
builder.Services.AddTransient<ConsumeService>();    
var host = builder.Build();

host.Run();
