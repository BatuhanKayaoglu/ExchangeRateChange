﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Common.ResponseViewModel
{
    public class AddProductResponseVM
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string ExchangeType { get; set; }
    }
}
