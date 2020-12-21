using BmesRestApi.Messages.DataTransferObjects.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Response.Order
{
    public class GetOrderResponse : ResponseBase
    {
        public OrderDto OrderDto { get; set; }
    }
}
