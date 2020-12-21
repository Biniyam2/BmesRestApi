using BmesRestApi.Services;
using BmesRestApi.Messages.Request.Cart;
using BmesRestApi.Messages.Response.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpDelete(template:"{cartId}/{cartItemId}")]
        public ActionResult<RemoveItemFromCartResponse> RemoveItemFromcart (long cartId, long cartItemId) 
        {
            RemoveItemFromCartRequest removeItemFromCartRequest = new RemoveItemFromCartRequest()
            {
                CartId = cartId,
                CartItmeId = cartItemId
            };
            var response = _cartService.RemoveItemFromCart(removeItemFromCartRequest);
            return response;
        }
        [HttpPost]
        public ActionResult<AddItemToCartResponse> AddItemToCart (AddItmeToCartRequest addItmeToCartRequest) 
        {
            var response = _cartService.AddItemToCart(addItmeToCartRequest);
            return response;
        }
        [HttpGet]
        public ActionResult<FetchCartResponse> GetCart() 
        {
            var fetchCartResponse = _cartService.FetchCart();
            return fetchCartResponse;
        }


    }
}
