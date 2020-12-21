using BmesRestApi.Messages.DataTransferObjects.Product;

namespace BmesRestApi.Messages.Response.Product
{
    public class GetProductResponse : ResponseBase
    {
        public ProductDto Product { get; set; }
    }
}
