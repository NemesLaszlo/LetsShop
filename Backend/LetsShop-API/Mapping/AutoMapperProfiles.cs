using AutoMapper;
using Core.Entities.Basket;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;
using Core.Entities.OrderAggregate.Helpers;
using Core.Entities.Product;
using LetsShop_API.Dtos;
using LetsShop_API.Helpers;

namespace LetsShop_API.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<CustomerBasketDto, CustomerBasket>();

            CreateMap<BasketItemDto, BasketItem>();

            CreateMap<AddressDto, OrderAddress>();

            CreateMap<Order, OrderToReturnDto>()
               .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
               .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl));
                //.ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}
