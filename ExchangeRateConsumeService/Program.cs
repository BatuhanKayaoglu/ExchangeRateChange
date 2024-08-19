using ExchangeRateConsumeService;
using Microsoft.AspNetCore.SignalR;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Run();
