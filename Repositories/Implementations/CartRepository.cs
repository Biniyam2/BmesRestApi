using BmesRestApi.Models.Cart;
using System;
using System.Collections.Generic;
using BmesRestApi.Database;
using System.Threading.Tasks;

namespace BmesRestApi.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly BmesDbContext _bmesDbContext;
        public CartRepository(BmesDbContext bmesDbContext)
        {
            _bmesDbContext = bmesDbContext;
        }
        public void DeleteCart(Cart cart)
        {
            _bmesDbContext.Carts.Remove(cart);
            _bmesDbContext.SaveChanges();
        }

        public void EditCart(Cart cart)
        {
            _bmesDbContext.Carts.Update(cart);
            _bmesDbContext.SaveChanges();
        }

        public Cart FindCartById(long Id)
        {
            var cart = _bmesDbContext.Carts.Find(Id);
            return cart;
        }

        public IEnumerable<Cart> GetCarts()
        {
            var carts = _bmesDbContext.Carts;
            return carts;
        }

        public void SaveCart(Cart cart)
        {
            _bmesDbContext.Carts.Add(cart);
            _bmesDbContext.SaveChanges();
        }
    }
}
