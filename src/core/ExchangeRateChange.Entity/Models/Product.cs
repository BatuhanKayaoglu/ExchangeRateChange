using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Entity.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public string ExchangeType { get; set; }
    }
}
