using BmesRestApi.Messages.DataTransferObjects.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.Cart
{
    using DataTransferObjects.Cart;
    public class AddItmeToCartRequest 
    {
        public CartItemDto CartItem { get; set; }
        public long CartId { get; set; }
        public long ProductId { get; set; }
    }
}
