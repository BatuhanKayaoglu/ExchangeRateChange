﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Common.ViewModels
{
    public class GetProductListVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public string ExchangeType { get; set; }
        public DateTime createDate { get; set; }
        public decimal? NewPrice { get; set; }
        public decimal? ExchangeSellRate { get; set; }
    }
}
