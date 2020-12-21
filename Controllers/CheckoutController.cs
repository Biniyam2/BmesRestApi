using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Services;
using BmesRestApi.Messages.Request.Checkout;
using BmesRestApi.Messages.Response.Checkout;
using Microsoft.AspNetCore.Authorization;

namespace BmesRestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;
        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }
        [HttpPost]
        public ActionResult<CheckoutResponse> Checkout(CheckoutRequest checkoutRequest)
        {
            var response = _checkoutService.ProcessCheckout(checkoutRequest);
            return response;
        }
    }
}
