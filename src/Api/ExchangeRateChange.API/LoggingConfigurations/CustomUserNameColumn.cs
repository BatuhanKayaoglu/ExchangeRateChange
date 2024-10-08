﻿using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace ExchangeRateChange.API.LoggingConfigurations
{
    public class CustomUserNameColumn : ILogEventEnricher
    {
        //public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        //{
        //    var (username, value) = logEvent.Properties.FirstOrDefault(x => x.Key == "UserName");
        //    if (value != null)
        //    {
        //        var getValue = propertyFactory.CreateProperty(username, value);
        //        logEvent.AddPropertyIfAbsent(getValue);
        //       }
        //}

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserName", "Username"));
        }
    }



}
