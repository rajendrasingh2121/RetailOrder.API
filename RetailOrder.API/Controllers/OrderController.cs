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
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: OrderController
        [HttpPost]
        [Route("AddOrder")]
        public async Task<bool> AddOrder([FromBody] OrderDTO orderDto)
        {
            return await _orderService.AddOrder(orderDto);                             
         
        }


        [HttpPut]
        [Route("UpdateOrderAddress")]
        public async Task<object> UpdateOrderAddress([FromBody] OrderDTO orderDto)
        {
            return await _orderService.AddOrder(orderDto);

        }


        [HttpPut]
        [Route("CancelOrder")]
        public async Task<object> CancelOrder(Guid orderId)
        {

            return await _orderService.CancelOrder(orderId);

        }

        [HttpGet]
        [Route("GetOrderById")]
        public async Task<object> GetOrderById(Guid orderId)
        {
            OrderDTO orderDTOs = await _orderService.GetOrderById(orderId);
            return orderDTOs;
        }

       

        [HttpGet]
        [Route("GetOrders")]
        public PagedResultsDTO<OrderDTO> GetOrders([FromQuery] OrderPaginationParameter orderPagination)
        {            
            PagedResultsDTO<OrderDTO> orderDTOs = _orderService.GetOrders(orderPagination);
            return orderDTOs;
        }

    }
}
