using BmesRestApi.Models.Shared;
using BmesRestApi.Models.Product;

namespace BmesRestApi.Models.Cart
{
    using Product;
    public class CartItem : BaseObject
    {
        public long CartId { get; set; }
        public Cart Cart { get; set; }
        public long ProductId { get; set; }
        public Product product { get; set; }
        public int Quantity { get; set; }

    }
}
