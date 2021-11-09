using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailOrder.API.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public string UserId { get; set; }

 
        public DateTime OrderTime { get; set; }
        public string Address { get; set; }

        public string Status { get; set; }

        // public sting OrderStatus
        public List<OrderLineItem> OrderDetails { get; set; }
    }
}
