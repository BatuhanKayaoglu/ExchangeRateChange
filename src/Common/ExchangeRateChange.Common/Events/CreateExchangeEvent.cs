using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Common.Events
{
    public class CreateExchangeEvent
    {
        public Guid Id { get; set; }        
        public double Price { get; set; }
        public string ExchangeType { get; set; }
    }
}
