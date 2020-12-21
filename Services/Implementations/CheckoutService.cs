using BmesRestApi.Messages;
using BmesRestApi.Messages.Request.Checkout;
using BmesRestApi.Messages.Response.Checkout;
using BmesRestApi.Models.Order;
using BmesRestApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Services.Implementations
{
    public class CheckoutService : ICheckoutService
    {
        private IOrderRepository _orderRepository;
        private MessageMapper _messageMapper;
        private ICustomerRepository _customerRepository;
        private IPersonRepositery _personRepositery;
        private IAddressRespository _addressRespository;
        private IOrderItemRepository _orderItemRepository;
        private ICartRepository _cartRepository;
        private ICartItemRepository _cartItemRepository;
        private ICartService _cartService;

        public CheckoutService(
            IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        IPersonRepositery personRepositery,
        IAddressRespository addressRespository,
        IOrderItemRepository orderItemRepository,
        ICartRepository cartRepository,
         ICartItemRepository cartItemRepository,
        ICartService cartService
            )
        {
            _messageMapper = new MessageMapper();
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _personRepositery = personRepositery;
            _addressRespository = addressRespository;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
        }

        public CheckoutResponse ProcessCheckout(CheckoutRequest checkoutRequest)
        {
            CheckoutResponse response = new CheckoutResponse();
            var customer = _messageMapper.MapToCustomer(checkoutRequest.CustomerDto);
            var person = customer.Person;
            _personRepositery.SavePerson(person);
            var address = _messageMapper.MapTopAddress(checkoutRequest.addressDto);
            _addressRespository.SaveAddress(address);

            customer.PersonId = person.Id;
            customer.Person = person;
            _customerRepository.SaveCustomer(customer);
            var cart = _cartService.GetCart();

            if(cart != null)
            {
                var cartItems = _cartItemRepository.FindCartItemsById(cart.Id);
                var cartTotal = _cartService.GetCartTotal();
                decimal shippingCharge = 0;
                var orderTotal = cartTotal + shippingCharge;
                var order = new Order
                {
                    OrderTotal = orderTotal,
                    OrderItemTotal = cartTotal,
                    ShippingCharge = shippingCharge,
                    AddressId = address.Id,
                    DeliveryAddresses = address,
                    CustomerId = customer.Id,
                    Customer = customer,
                    OrderStatus = OrderStatus.Submitted
                };
                _orderRepository.SaveOrder(order);
                foreach (var cartItem in cartItems)
                {
                    var orderItem = new OrderItem
                    {
                    Quantity = cartItem.Quantity,
                    Order = order,
                    OrderId = order.Id,
                    Product = cartItem.product,
                    ProductId = cartItem.ProductId
                    };
                    _orderItemRepository.SaveOrderItem(orderItem);
                }
                _cartRepository.DeleteCart(cart);

                response.StatusCode = System.Net.HttpStatusCode.Created;
                response.Messages.Add(item: "Order Created");
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.NoContent;
                response.Messages.Add(item: "Order Emptiy");
            }
      

            return response;
        }
    }


}
