using BmesRestApi.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Repositories
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetCarts();
        Cart FindCartById(long Id);
        void DeleteCart(Cart cart);
        void EditCart(Cart cart);
        void SaveCart(Cart cart);

    }
}
