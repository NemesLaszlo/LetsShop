using AutoMapper;
using Microsoft.Extensions.Configuration;
using Core.Entities.OrderAggregate;
using LetsShop_API.Dtos;

namespace LetsShop_API.Helpers
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _config;

        public OrderItemUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ItemOrdered.PictureUrl))
            {
                return _config.GetSection("ApiUrl").Value + source.ItemOrdered.PictureUrl;
            }
            return null;
        }
    }
}
