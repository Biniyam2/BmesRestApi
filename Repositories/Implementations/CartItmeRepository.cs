using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BmesRestApi.Models.Cart;
using BmesRestApi.Database;
namespace BmesRestApi.Repositories.Implementations
{
    public class CartItmeRepository : ICartItemRepository
    {
        private BmesDbContext _BmesDbContext;
        public CartItmeRepository(BmesDbContext BmesDbContext)
        {
            _BmesDbContext = BmesDbContext;
        }
        public void DeleteCartItem(CartItem cartItem)
        {
             _BmesDbContext.CartItems.Remove(cartItem);
            _BmesDbContext.SaveChanges();
        }

        public void EditCartItem(CartItem cartItem)
        {
            _BmesDbContext.CartItems.Update(cartItem);
            _BmesDbContext.SaveChanges();
        }

        public CartItem FindCartItemById(long id)
        {
            var cartItem = _BmesDbContext.CartItems.Find(id);
            return cartItem;
        }

        public IEnumerable<CartItem> FindCartItemsById(long CartID)
        {
            var cartItmes = _BmesDbContext.CartItems.Where(cartItme => cartItme.CartId == CartID)
                                                    .Include(navigationPropertyPath: c => c.product);
                                                       
            return cartItmes;
        }

        public void SaveCartItem(CartItem cartItem)
        {
            _BmesDbContext.CartItems.Add(cartItem);
            _BmesDbContext.SaveChanges();
        }
    }
}
