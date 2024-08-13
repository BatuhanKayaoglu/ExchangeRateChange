using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Entity.Models
{
    public enum ExchangeType
    {
        DOLAR,
        EURO,
        STERLİN,
        [Display(Name = "GRAM ALTIN")]
        GRAMALTIN
    }
    public class Exchange: BaseEntity
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public ExchangeType ExchageType { get; set; }
        public string ExchangeName { get; set; }
    }
}
