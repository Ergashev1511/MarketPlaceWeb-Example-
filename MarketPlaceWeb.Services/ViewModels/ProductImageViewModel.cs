﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.ViewModels
{
    public class ProductImageViewModel
    {
        public long  Id { get; set; }
        public string Name { get; set; }
        public long?  ProductId { get; set; }
    }
}