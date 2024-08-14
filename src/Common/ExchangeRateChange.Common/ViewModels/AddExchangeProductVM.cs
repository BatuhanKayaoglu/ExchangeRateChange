using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Common.ViewModels
{
    public class AddExchangeProductVM
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }  
    }
}
