using BmesRestApi.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Models.Cart
{
    public class Cart : BaseObject
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public string UniqueCartId { get; set; }
        public CartStatus CartStatus { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }

    }
}
