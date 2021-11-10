using RetailOrder.API.Helpers;
using RetailOrder.API.Models;
using RetailOrder.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailOrder.API.Sevices
{
    public interface IOrderService
    {
        Task<OrderDTO> GetOrderById(Guid ownerId);
        PagedResultsDTO<OrderDTO> GetOrders(OrderPaginationParameter orderPaginationParameter);
        Task<bool> AddOrder(OrderDTO order);
        Task<bool> UpdateOrderAddress(Guid orderId, string address);

        Task<OrderDTO> UpdateOrderItemDetails(Guid orderId, List<OrderLineItemDTO> orderItemDetails);
        Task<bool> CancelOrder(Guid orderId);
     
    }
}
