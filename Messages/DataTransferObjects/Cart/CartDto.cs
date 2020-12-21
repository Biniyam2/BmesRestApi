using BmesRestApi.Messages.DataTransferObjects.Shared;
using BmesRestApi.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.DataTransferObjects.Cart
{
    public class CartDto : BaseDto
    {
        public CartDto()
        {
            CartItemsDto = new List<CartItemDto>();
        }
        public string UniqueCartIdDto { get; set; }
        public int CartStatusDto { get; set; }
        public IEnumerable<CartItemDto> CartItemsDto { get; set; }
    }
}
