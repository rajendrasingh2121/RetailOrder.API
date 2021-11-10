﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailOrder.API.Models.Dtos
{
    public class OrderLineItemDTO
    {
            
        public Guid OrderId { get; set; }
      
        public Guid ProductId { get; set; }

        public int Count { get; set; }
        public string ProductName { get; set; }
        public double Price
        {
            get; set;

        }
    }
}
