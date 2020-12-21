using BmesRestApi.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Repositories
{
    public interface ICartItemRepository
    {
        CartItem FindCartItemById(long id);
        IEnumerable<CartItem> FindCartItemsById(long cartID);
        void DeleteCartItem(CartItem cartItem);
        void EditCartItem(CartItem cartItem);
        void SaveCartItem(CartItem cartItem);

    }
}
