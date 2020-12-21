using BmesRestApi.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Database;

namespace BmesRestApi.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BmesDbContext _bmesDbContext;
        public OrderRepository(BmesDbContext bmesDbContext)
        {
            _bmesDbContext = bmesDbContext;
        }
        public void DeleteOrder(Order order)
        {
            _bmesDbContext.Orders.Remove(order);
            _bmesDbContext.SaveChanges();
        }

        public void EditOrder(Order order)
        {
            _bmesDbContext.Orders.Update(order);
            _bmesDbContext.SaveChanges();
        }

        public Order FindOrderById(long Id)
        {
           var found = _bmesDbContext.Orders.Find(Id);
            return found;
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = _bmesDbContext.Orders;
            return orders;
        }

        public void SaveOrder(Order order)
        {
            _bmesDbContext.Orders.Add(order);
            _bmesDbContext.SaveChanges();
        }
    }
}
