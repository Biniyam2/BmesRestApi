using BmesRestApi.Models.Addresses;
using System.Collections.Generic;
using BmesRestApi.Models.Shared;


namespace BmesRestApi.Models.Order
{
  
    using Customer;
    public class Order : BaseObject
    {
        public decimal OrderTotal { get; set; }
        public decimal OrderItemTotal { get; set; }
        public decimal ShippingCharge { get; set; }
        public long CustomerId { get; set; }
        public long AddressId { get; set; }
        public Customer Customer { get; set; }
        public Address DeliveryAddresses { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
