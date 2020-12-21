using BmesRestApi.Messages.DataTransferObjects.Addresses;
using BmesRestApi.Messages.DataTransferObjects.Cart;
using BmesRestApi.Messages.DataTransferObjects.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.Checkout
{
    public class CheckoutRequest
    {
        public CustomerDto CustomerDto { get; set; }
        public AddressDto addressDto { get; set; }
        public CartDto cartDto { get; set; }
    }
}
