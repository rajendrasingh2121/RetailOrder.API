using RetailOrder.API.Helpers;
using RetailOrder.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailOrder.API.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(Order order);
        Task<bool> UpdateOrderAddress(Guid orderId, string address);

        Task<Order> UpdateOrderItemDetails(Guid orderId, List<OrderLineItem> orderItemDetails);
        Task<bool> CancelOrder(Guid orderId);
        Task<Order> GetOrderById(Guid orderId);

        PagedList<Order> GetOrders(OrderPaginationParameter orderPaginationParameter);



    }
}
