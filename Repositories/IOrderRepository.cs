using BmesRestApi.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Repositories
{
    public interface IOrderRepository
    {
        Order FindOrderById(long Id);
        IEnumerable<Order> GetOrders();
        void DeleteOrder(Order order);
        void SaveOrder(Order order);
        void EditOrder(Order order);
    }
}
