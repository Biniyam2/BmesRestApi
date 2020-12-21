using BmesRestApi.Messages.Request.Cart;
using BmesRestApi.Messages.Response.Cart;
using BmesRestApi.Messages;
using BmesRestApi.Repositories;

using BmesRestApi.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BmesRestApi.Services.Implementations
{
    public class CartService : ICartService
    {
        private const string UniqueCartIdSessionKey = "UniqueCartId";
        private readonly HttpContext _httpContext;
        private readonly IProductRepository _productRepository;
        private MessageMapper _messageMapper;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;

        public CartService(
            ICartItemRepository cartItemRepository,
            ICartRepository cartRepository, 
            IProductRepository productRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _productRepository = productRepository;
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _messageMapper = new MessageMapper();
        }
        public AddItemToCartResponse AddItemToCart(AddItmeToCartRequest addItmeToCartRequest)
        {
            AddItemToCartResponse response = new AddItemToCartResponse();
            var cart = GetCart();
            if(cart != null)
            {
                var existingCartItem = _cartItemRepository.FindCartItemsById(cart.Id)
                                        .FirstOrDefault(c => c.ProductId == addItmeToCartRequest.ProductId);
                if(existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                    _cartItemRepository.EditCartItem(existingCartItem);
                    response.CartItem = _messageMapper.MapToCartItmeDto(existingCartItem);
                }
                else
                {
                    var product = _productRepository.FindProductById(addItmeToCartRequest.ProductId);
                    if(product != null)
                    {
                        var carItem = new CartItem //model
                        {
                            CartId = cart.Id,
                            Cart = cart,
                            ProductId = addItmeToCartRequest.ProductId,
                            product = product,
                             Quantity = 1
                        };
                        _cartItemRepository.SaveCartItem(carItem);
                        response.CartItem = _messageMapper.MapToCartItmeDto(carItem);
                    }
                }
            }
            else
            {
                var product = _productRepository.FindProductById(addItmeToCartRequest.ProductId);
                if(product != null)
                {
                    var newCart = new Cart
                    {
                        UniqueCartId = UniqueCartId(),
                        CartStatus = CartStatus.Open
                    };
                    _cartRepository.SaveCart(newCart);
                    var cartItem = new CartItem
                    {
                        CartId = newCart.Id,
                        Cart = newCart,
                        product = product,
                        ProductId = addItmeToCartRequest.ProductId,
                        Quantity = 1
                    };

                    _cartItemRepository.SaveCartItem(cartItem);
                    response.CartItem = _messageMapper.MapToCartItmeDto(cartItem);
                }
            }
            return response;
        }

        public int CartItemsCount()
        {
            var count = 0;
            var cartItmes = GetAllCartItems();
            foreach (var cartItem in cartItmes)
            {
                count += cartItem.Quantity;
            }
            return count;
        }

        public FetchCartResponse FetchCart()
        {
            FetchCartResponse response = new FetchCartResponse();
            var cart = GetCart();
            IList<CartItem> cartItems = new List<CartItem>();
            if (cart != null)
            {
                cartItems = _cartItemRepository.FindCartItemsById(cart.Id).ToArray();
            }
            var cartItemsDto = _messageMapper.MapToCartItemDtos(cartItems);
            var cartDto = _messageMapper.MaptoCartDto(cart);
            cartDto.CartItemsDto = cartItemsDto;
            response.Cart = cartDto;
            return response;
        }

        public IEnumerable<CartItem> GetAllCartItems()
        {
            IList<CartItem> cartItems = new List<CartItem>();
            var cart = GetCart();
            if(cart != null)
            {
                cartItems = _cartItemRepository.FindCartItemsById(cart.Id).ToArray();
            }
            return cartItems;
        }

        public Cart GetCart()
        {
            var uniqueId = UniqueCartId(); // to create or to get that is already created (Unique Id card)
            var cart = _cartRepository.GetCarts().FirstOrDefault(c => c.UniqueCartId == uniqueId);
            return cart;
        }

        public decimal GetCartTotal()
        {
            decimal total = 0;
            var cartItmes = GetAllCartItems();
            foreach (var cartItem in cartItmes)
            {
                var product = _productRepository.FindProductById(cartItem.ProductId);
                total += cartItem.Quantity * product.Price;
            }
            return total;
        }

        public RemoveItemFromCartResponse RemoveItemFromCart(RemoveItemFromCartRequest removeItemFromCartRequest)
        {
            RemoveItemFromCartResponse response = new RemoveItemFromCartResponse();
            var cartItem = _cartItemRepository.FindCartItemById(removeItemFromCartRequest.CartItmeId);
            _cartItemRepository.DeleteCartItem(cartItem);

            response.CartItemId = cartItem.Id;
            return response;
        }

        public string UniqueCartId() // creating a uniqueId for the cart
        {
           if(!string.IsNullOrWhiteSpace(_httpContext.Session.GetString(UniqueCartIdSessionKey)))
           {
                return _httpContext.Session.GetString(UniqueCartIdSessionKey);
           }
           else
           {                   //create new unique ID and convet it to string
                var uniqueId = Guid.NewGuid().ToString();
                _httpContext.Session.SetString(UniqueCartIdSessionKey, uniqueId); //_httpContext is a Cookes Database
                return _httpContext.Session.GetString(UniqueCartIdSessionKey);
           }
        }
    }
}
