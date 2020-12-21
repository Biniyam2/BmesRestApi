using BmesRestApi.Messages.Request.Product;
using BmesRestApi.Messages.Response.Product;


namespace BmesRestApi.Services
{
    public interface IProductService
    {
        CreateProductResponse SaveProduct(CreateProductRequest productRequest);
        UpdateProductResponse EditProduct(UpdateProductRequest updateProductRequest);
        FetchOrdersResponse GetProducts(FetchProductRequest fetchProductRequest);
        GetProductResponse GetProduct(GetProductRequest getProductRequest);
        DeleteProductResponse DeleteProduct(DeleteProductRequest productRequest);
    }
}
