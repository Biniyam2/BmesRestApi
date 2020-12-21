using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Messages.Request.Cart;
using BmesRestApi.Messages.Response.Cart;
using BmesRestApi.Models.Cart;

namespace BmesRestApi.Services
{
    public interface ICartService
    {
        AddItemToCartResponse AddItemToCart(AddItmeToCartRequest addItmeToCartRequest);
        RemoveItemFromCartResponse RemoveItemFromCart(RemoveItemFromCartRequest removeItemFromCartRequest);
        int CartItemsCount();
        decimal GetCartTotal();
        Cart GetCart();
        string UniqueCartId();
        IEnumerable<CartItem> GetAllCartItems();
        FetchCartResponse FetchCart();
    }
}
