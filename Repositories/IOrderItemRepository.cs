using BmesRestApi.Models.Order;
using System.Collections.Generic;

namespace BmesRestApi.Repositories
{
    public interface IOrderItemRepository
    {
        OrderItem FindOrderItemById(long Id);
        IEnumerable<OrderItem> FindOrderItemsByOrderId(long orderId);
        IEnumerable<OrderItem> GetOrderItems();
        void DeleteOrderItem(OrderItem orderItems);
        void SaveOrderItem(OrderItem orderItems);
        void EditOrderItem(OrderItem orderItems);
    }
}
