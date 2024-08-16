using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateConsumeService
{
    public class ExchangeRateReceiverEvent
    {
        public class CurrencyPrice
        {
            public decimal BuyPrice { get; set; }
            public decimal SellPrice { get; set; }
        }

        public class CurrencyData
        {
            public Dictionary<string, CurrencyPrice> CurrencyDict { get; set; }
        }

    }
}
