using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateConsumeService
{
    public class ExchangeRateReceiverEvent
    {
        public string Currency { get; set; }
        public string BuyPrice { get; set; }
        public string SellPrice { get; set; }
        public string Id { get; set; }
        public int Price { get; set; }
    }
}
