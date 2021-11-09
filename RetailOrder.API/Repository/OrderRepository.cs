using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RetailOrder.API.DBContexts;
using RetailOrder.API.Helpers;
using RetailOrder.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RetailOrder.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
    

        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }


        public PagedList<Order> GetOrders(OrderPaginationParameter orderParameters)
		{
			return PagedList<Order>.ToPagedList(FindAll(),
				orderParameters.PageNumber,
				orderParameters.PageSize);
		}

		

	
        public async Task<bool> AddOrder(Order order)
        {
            try
            {
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


        public async Task<bool> UpdateOrderAddress(Guid orderId, string address)
        {
            try
            {
                Order order = await _db.Orders.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
                if (order == null)
                {
                    return false;
                }
                order.Address = address;
                _db.Orders.Update(order);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Order> UpdateOrderItemDetails(Guid orderId, List<OrderLineItem> orderItemDetails)
        {
            try
            {
                Order order = await _db.Orders.Include(o => o.OrderDetails).Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
                if (order == null)
                {
                    return null;
                }
                order.OrderDetails = orderItemDetails;
                _db.Orders.Update(order);
                await _db.SaveChangesAsync();
                return order;
            }
            catch (Exception)
            {

                return null;
            }
        }

      

        

        public IQueryable<Order> FindAll()
        {           

            return _db.Orders.Include(o => o.OrderDetails).AsNoTracking();
        }

       
        public Task<Order> GetOrderById(Guid orderId)
        {
            return _db.Orders.Include(o => o.OrderDetails).Where(order => order.OrderId.Equals(orderId))            
                .FirstOrDefaultAsync();
        }
        public async Task<bool> CancelOrder(Guid orderId)
        {
            try
            {
                Order order = await _db.Orders.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
                if (order == null)
                {
                    return false;
                }
                order.Status = "Cancelled";
               _db.Orders.Update(order);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
       
    }
}
