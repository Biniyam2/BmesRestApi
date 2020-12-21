using Microsoft.AspNetCore.Mvc;
using BmesRestApi.Messages.Request.Product;
using BmesRestApi.Messages.Response.Product;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace BmesRestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
       public ProductController(IProductService productService)
       {
            _productService = productService;
       }
        [AllowAnonymous]
       [HttpGet(template:"{id}")]
        public ActionResult<GetProductResponse> GetProduct (long id) 
        {
            var getProductResquest = new GetProductRequest
            { Id = id };
            var gerProductResponse = _productService.GetProduct(getProductResquest);
            return gerProductResponse;
        }
        [AllowAnonymous]
        [HttpGet(template:"{categorySlug}/{brandSlug}/{page}/{productsPerPage}")]
        public ActionResult<FetchOrdersResponse> GetProducts (string categorySlug, string brandSlug, int page, int productsPerPage) 
        {
            var fetchProductRequest = new FetchProductRequest
            {
                PageNumber = page,
                BrandSlug = brandSlug,
                CategorySlug = categorySlug, 
                ProductPerPage = productsPerPage
            };
            var fetchProductResponse = _productService.GetProducts(fetchProductRequest);
            return fetchProductResponse;
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete(template:"{id}")]
        public ActionResult<DeleteProductResponse>  DeleteProduct (long id) 
        {
            var deleteProductRequest = new DeleteProductRequest
            {
                Id = id
            };
            var deleteProductReponse = _productService.DeleteProduct(deleteProductRequest);

            return deleteProductReponse;
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut()]
        public ActionResult<UpdateProductResponse> PutProduct (UpdateProductRequest updateProductRequest) // model binding
        {
            var uploadProductResponse = _productService.EditProduct(updateProductRequest);
            return uploadProductResponse;
        
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<CreateProductResponse> PostProduct (CreateProductRequest createProductRequest)// model binding
        {
            var createProductResponse = _productService.SaveProduct(createProductRequest);
            return createProductResponse;
        }
    }
}
