using BmesRestApi.Models.Cart;
using BmesRestApi.Messages.DataTransferObjects.Shared;
using BmesRestApi.Messages.DataTransferObjects.Product;

namespace BmesRestApi.Messages.DataTransferObjects.Cart
{

    public class CartItemDto : BaseDto
    {
        public long CartIdDto { get; set; }
        public ProductDto productDto { get; set; }
        public int QuantityDto { get; set; }
    }
}
