using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Common.Enums
{
    public enum ExchangeType
    {
        DOLAR,
        EURO,
        STERLİN,
        [Display(Name = "GRAM ALTIN")]
        GRAMALTIN
    }
}
