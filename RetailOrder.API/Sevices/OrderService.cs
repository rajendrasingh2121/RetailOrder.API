using AutoMapper;
using RetailOrder.API.Helpers;
using RetailOrder.API.Models;
using RetailOrder.API.Models.Dtos;
using RetailOrder.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailOrder.API.Sevices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private MappingConfig _mapper;
        public OrderService(IOrderRepository orderRepository, MappingConfig mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<OrderDTO> GetOrderById(Guid orderId)
        {
            Order order = await _orderRepository.GetOrderById(orderId);
            OrderDTO orderDto = _mapper._iMapper.Map<Order, OrderDTO>(order);
            return orderDto;
        }

        public PagedResultsDTO<OrderDTO> GetOrders(OrderPaginationParameter orderPaginationParameter)
        {
            PagedList<Order> orders = _orderRepository.GetOrders(orderPaginationParameter);
            return _mapper.MapOrdersToPageResultDTOList(orders);
        }


        public Task<bool> AddOrder(OrderDTO orderDto)
        {

            var order = new Order()
            {
                OrderId= orderDto.OrderId,
                OrderTime=DateTime.Now,
               Address=orderDto.Address,
               Status="Placed",
               UserId=orderDto.UserId,
                OrderDetails = (from item in orderDto.OrderDetails
                                select new OrderLineItem()
                                { ProductId = item.ProductId, Count = item.Count,
                                  Price=item.Price,ProductName=item.ProductName }).ToList()
            };

            return _orderRepository.AddOrder(order);
        }


        public Task<bool> UpdateOrderAddress(Guid orderId, string address)
        {
            return _orderRepository.UpdateOrderAddress(orderId, address);
        }

        public async Task<OrderDTO> UpdateOrderItemDetails(Guid orderId, List<OrderLineItemDTO> orderItemDetails)
        {
            List<OrderLineItem> orderdetails = _mapper._iMapper.Map<List<OrderLineItemDTO>, List<OrderLineItem>>(orderItemDetails);
            Order order = await _orderRepository.UpdateOrderItemDetails(orderId, orderdetails);
            OrderDTO orderDto = _mapper._iMapper.Map<Order, OrderDTO>(order);
            return orderDto;
        }

        public Task<bool> CancelOrder(Guid orderId)      
        {         
            return _orderRepository.CancelOrder(orderId);
        }            
       
    }
}
