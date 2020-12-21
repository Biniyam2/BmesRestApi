using BmesRestApi.Messages.Request.Checkout;
using BmesRestApi.Messages.Response.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Services
{
    public interface ICheckoutService
    {
        CheckoutResponse ProcessCheckout(CheckoutRequest checkoutRequest);
    }
}
