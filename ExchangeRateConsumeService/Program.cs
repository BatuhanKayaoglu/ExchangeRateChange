using ExchangeRateConsumeService;
using Microsoft.AspNetCore.SignalR;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Services.AddHttpClient();   
var host = builder.Build();

host.Run();
