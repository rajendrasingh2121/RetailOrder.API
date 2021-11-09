using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetailOrder.API.DBContexts;
using RetailOrder.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailOrder.API.Data
{
    public static class DBInitializer
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                Order order = new Order
                {
                    OrderId = Guid.NewGuid(),
                    Address = "Donegal",
                    Status = "Placed",
                    OrderDetails = new List<OrderLineItem> { new OrderLineItem {ProductId=Guid.NewGuid(),
                   ProductName="milk", Count=5,
                   Price=6},
             new OrderLineItem {ProductId=Guid.NewGuid(),
                   ProductName="bread", Count=2,
                   Price=10
                   }
                }
                };
                context.Orders.Add(order);

                context.SaveChanges();
            }
        }


    }
}
