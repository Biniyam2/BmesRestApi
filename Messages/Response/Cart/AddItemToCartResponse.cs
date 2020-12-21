using BmesRestApi.Messages.DataTransferObjects.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Response.Cart
{
    public class AddItemToCartResponse : ResponseBase
    {
        public CartItemDto CartItem { get; set; }
    }
}
