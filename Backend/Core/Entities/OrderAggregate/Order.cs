using Core.Entities.OrderAggregate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderAddress ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }

        public Order()
        {
        }

        public Order(List<OrderItem> orderItems, string buyerEmail, OrderAddress shipToAddress, DeliveryMethod deliveryMethod, decimal subtotal, string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
            PaymentIntentId = paymentIntentId;

            shipToAddress.Order = this;
            shipToAddress.OrderId = this.Id;

            orderItems.ForEach(oi => {
                oi.Order = this;
                oi.OrderId = this.Id;
            });
        }

        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }

    }
}
