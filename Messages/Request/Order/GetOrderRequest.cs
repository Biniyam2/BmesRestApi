using System;
using System.Collections.Generic;
using BmesRestApi.Models.Order;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.Order
{
    using Order;
    public class GetOrderRequest
    {
        public long Id { get; set; }
        public BmesRestApi.Models.Order.Order Order { get; set; }
    }
}
