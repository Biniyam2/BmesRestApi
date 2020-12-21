using BmesRestApi.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Database;

namespace BmesRestApi.Repositories.Implementations
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly BmesDbContext _bmesDbContext;
        public OrderItemRepository(BmesDbContext bmesDbContext)
        {
            _bmesDbContext = bmesDbContext;
        }
        public void DeleteOrderItem(OrderItem orderItems)
        {
            _bmesDbContext.OrderItems.Remove(orderItems);
            _bmesDbContext.SaveChanges();
        }

        public void EditOrderItem(OrderItem orderItems)
        {
            _bmesDbContext.OrderItems.Update(orderItems);
            _bmesDbContext.SaveChanges();
        }

        public OrderItem FindOrderItemById(long Id)
        {
            var found = _bmesDbContext.OrderItems.Find(Id);
            return found;
        }

        public IEnumerable<OrderItem> FindOrderItemsByOrderId(long orderId)
        {
            var orderItems = _bmesDbContext.OrderItems.Where(p => p.OrderId == orderId);
            return orderItems;
        }

        public IEnumerable<OrderItem> GetOrderItems()
        {
            var orderItems = _bmesDbContext.OrderItems;
            return orderItems;
        }

        public void SaveOrderItem(OrderItem orderItems)
        {
            _bmesDbContext.OrderItems.Add(orderItems);
            _bmesDbContext.SaveChanges();
        }
    }
}
