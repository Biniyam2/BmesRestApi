using BmesRestApi.Messages.DataTransferObjects.Shared;
using BmesRestApi.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.DataTransferObjects.Order
{
    public class OrderDto : BaseDto
    {
        public decimal OrderTotalDto { get; set; }
        public decimal OrderItemTotalDto { get; set; }
        public decimal ShippingChargeDto { get; set; }
        public long CustomerIdDto { get; set; }
        public long AddressIdDto { get; set; }
        public int OrderStatusDto { get; set; }
        public IEnumerable<OrderItem> OrderItemsDto { get; set; }
    }
}
