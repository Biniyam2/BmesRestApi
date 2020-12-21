using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BmesRestApi.Messages.Request.Order;
using BmesRestApi.Messages.Response.Order;
using BmesRestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BmesRestApi.Messages.Response.Category;
using BmesRestApi.Messages.Request.Category;

namespace BmesRestApi.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route(template:"api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
       
        [HttpGet(template: "{id}")]
        public ActionResult<GetOrderResponse> GetOrder(long id)
        {
            var getRequest = new GetOrderRequest
            {
                Id = id
            };
            var getResponse = _orderService.GetOrder(getRequest);
            return getResponse;
        }
        //[HttpGet]
        //public ActionResult<FetchOrdersResponse> GetOrders()
        //{
        //    var fetchRequest = new FetchOrderRequest();
        //    var fetchResponse = _orderService.GetOrders(fetchRequest);
        //    return fetchResponse;
        //    //throw new NotImplementedException();
        //}

    }
}
