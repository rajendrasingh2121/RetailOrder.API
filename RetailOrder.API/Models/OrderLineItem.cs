using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RetailOrder.API.Models
{
    public class OrderLineItem
    {
        [Key]
        public int OrderDetailsId { get; set; }
        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }
       
        //public virtual Order Order { get; set; }
        public Guid ProductId { get; set; }

        public int Count { get; set; }
        public string ProductName { get; set; }
        public double Price
        {
            get; set;

        }
        }
}
