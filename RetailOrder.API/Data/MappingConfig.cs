using AutoMapper;
using RetailOrder.API.Helpers;
using RetailOrder.API.Models;
using RetailOrder.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailOrder.API
{
    public class MappingConfig
    {
        public MappingConfig()
        {
            var mapperConfig = new MapperConfiguration(config => {

                config.CreateMap<OrderDTO, Order>();
                config.CreateMap<Order, OrderDTO>();
                config.CreateMap<OrderLineItem, OrderLineItemDTO>();
                config.CreateMap< OrderLineItemDTO, OrderLineItem>();
            });
            _iMapper = mapperConfig.CreateMapper();
        }

        public IMapper _iMapper { get; set; }
       
        public PagedResultsDTO<OrderDTO> MapOrdersToPageResultDTOList(PagedList<Order> orders)
        {

            return new PagedResultsDTO<OrderDTO>()
            {
                TotalPages = orders.TotalPages,
                PageIndex = orders.CurrentPage,
                PageSize = orders.PageSize,
                TotalRecords = orders.TotalCount,
                Results = _iMapper.Map<List<Order>, List<OrderDTO>>(orders)
            };

        }
    }
}
