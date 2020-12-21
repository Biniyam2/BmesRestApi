using BmesRestApi.Messages.Request.Product;
using BmesRestApi.Messages.Response.Product;
using BmesRestApi.Repositories;
using BmesRestApi.Messages;
using BmesRestApi.Services;


namespace BmesRestApi.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly MessageMapper _messageMapper;
        private readonly ICatalogueService _catalogueService;
        public ProductService( IProductRepository productRepository, ICatalogueService catalogueService)
        {
            _messageMapper = new MessageMapper();
            _productRepository = productRepository;
            _catalogueService = catalogueService;
        }
        public DeleteProductResponse DeleteProduct(DeleteProductRequest productRequest)
        {
            var product = _productRepository.FindProductById(productRequest.Id);
            _productRepository.DeleteProduct(product);
            var productDto = _messageMapper.MapToProductDto(product);

            return new DeleteProductResponse
            { Product = productDto };
        }
        public UpdateProductResponse EditProduct(UpdateProductRequest updateProductRequest)
        {
            UpdateProductResponse updateProductResponse = null;
            if (updateProductRequest.Id == updateProductRequest.Id)
            {
                var product = _messageMapper.MapToProduct(updateProductRequest.product);
                _productRepository.EditProduct(product);
                _messageMapper.MapToProductDto(product);
                return new UpdateProductResponse
                {

                };
            }
            return updateProductResponse;
        }

        public GetProductResponse GetProduct(GetProductRequest getProductRequest)
        {
            GetProductResponse getProductResponse = null;
            if (getProductRequest.Id > 0)
            {
                var product = _productRepository.FindProductById(getProductRequest.Id);
                var productDto = _messageMapper.MapToProductDto(product);
                return new GetProductResponse
                {
                    Product = productDto
                };
            }
            return getProductResponse;
        }

        public FetchOrdersResponse GetProducts(FetchProductRequest fetchProductRequest)
        {
            var fetchProductResponse = _catalogueService.FetchProducts(fetchProductRequest);
            return fetchProductResponse;
        }

        public CreateProductResponse SaveProduct(CreateProductRequest productRequest)
        {
            var product = _messageMapper.MapToProduct(productRequest.product);
                _productRepository.SaveProduct(product);
            var productDto = _messageMapper.MapToProductDto(product);
            return new CreateProductResponse
            { 
                Product = productDto
            };
        }

    }
}
