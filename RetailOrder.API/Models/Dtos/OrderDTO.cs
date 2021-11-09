using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailOrder.API.Models.Dtos
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public string UserId { get; set; }

        public double OrderTotal { get; set; } 
        public string Address { get; set; }

        // public sting OrderStatus
        public List<OrderLineItem> OrderDetails { get; set; }
    }
}
