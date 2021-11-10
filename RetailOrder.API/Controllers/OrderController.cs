using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailOrder.API.Models;
using RetailOrder.API.Models.Dtos;
using RetailOrder.API.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailOrder.API.Controllers
{

    /// <summary>
    /// This controller handle all the operation related to orders
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

       /// <summary>
       /// Add new order
       /// </summary>
       /// <param name="orderDto">order details</param>
       /// <returns></returns>
        [HttpPost]
        [Route("AddOrder")]
        public async Task<bool> AddOrder([FromBody] OrderDTO orderDto)
        {
            return await _orderService.AddOrder(orderDto);                             
         
        }

        /// <summary>
        /// Updated Order Address
        /// </summary>
        /// <param name="orderId"> order id</param>
        /// <param name="newAddress">new adddress </param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateOrderAddress")]
        public async Task<object> UpdateOrderAddress(Guid orderId, string newAddress)
        {
            return await _orderService.UpdateOrderAddress(orderId,newAddress);

        }

        /// <summary>
        /// update Order Details
        /// </summary>
        /// <param name="orderId">order id</param>
        /// <param name="orderItemDto">new order details </param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateOrderDetails")]
        public async Task<object> UpdateOrderDetails(Guid orderId, [FromBody] List<OrderLineItemDTO> orderItemDto)
        {
            return await _orderService.UpdateOrderItemDetails(orderId, orderItemDto);

        }

        /// <summary>
        /// Cancel order based on order id
        /// set the order status as Cancelled
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("CancelOrder")]
        public async Task<object> CancelOrder(Guid orderId)
        {

            return await _orderService.CancelOrder(orderId);

        }

        /// <summary>
        /// Get order details by Id
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOrderById")]
        public async Task<object> GetOrderById(Guid orderId)
        {
            OrderDTO orderDTOs = await _orderService.GetOrderById(orderId);
            return orderDTOs;
        }

       
        /// <summary>
        /// Get the orders based on paging
        /// </summary>
        /// <param name="orderPagination">pagination parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOrders")]
        public PagedResultsDTO<OrderDTO> GetOrders([FromQuery] OrderPaginationParameter orderPagination)
        {            
            PagedResultsDTO<OrderDTO> orderDTOs = _orderService.GetOrders(orderPagination);
            return orderDTOs;
        }

    }
}
