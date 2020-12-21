using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Models.Product;

namespace BmesRestApi.Models.Order
{
    using BmesRestApi.Models.Shared;
    using Product;
    public class OrderItem : BaseObject
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
