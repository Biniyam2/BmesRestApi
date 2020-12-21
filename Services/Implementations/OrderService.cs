using BmesRestApi.Messages;
using BmesRestApi.Messages.Request.Order;
using BmesRestApi.Messages.Response.Order;
using BmesRestApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly MessageMapper _messageMapper;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _messageMapper = new MessageMapper();
        }
        public GetOrderResponse GetOrder(GetOrderRequest getOrderRequest)
        {
            return new GetOrderResponse();
        }

        public FetchOrdersResponse GetOrders(FetchOrderRequest fetchOrderRequest)
        {
            return new FetchOrdersResponse();
        }
    }
}
