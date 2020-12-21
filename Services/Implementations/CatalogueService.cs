using System;
using System.Collections.Generic;
using System.Linq;
using BmesRestApi.Messages.Request.Product;
using BmesRestApi.Messages.Response.Product;
using BmesRestApi.Repositories;
using BmesRestApi.Messages;
using BmesRestApi.Models.Product;

namespace BmesRestApi.Services.Implementations
{
    public class CatalogueService : ICatalogueService
    {
        
        private IProductRepository _productRepository;
        private MessageMapper _messageMapper;
        public CatalogueService(IProductRepository productRepository) //Constracter
        {
            _productRepository = productRepository;
            _messageMapper = new MessageMapper();
        }

        public FetchOrdersResponse FetchProducts (FetchProductRequest fetchProductRequest)
        {
            IEnumerable<Product> products = new List<Product>();
            int prouductCount = 0;
            //The user is not filetering neither category (not selected)   nor  brand (not selected)
            if (fetchProductRequest.CategorySlug == "all-categories" && fetchProductRequest.BrandSlug == "all-brands")
            {
                prouductCount = _productRepository.GetAllProducts().Count();
                products = _productRepository.GetAllProducts()
                      .Where(product => product.ProductStatus == ProductStatus.Active) // the products that are active 
                      .Skip((fetchProductRequest.PageNumber - 1) * fetchProductRequest.ProductPerPage) // if you are on page 3 skip page 2 and 1
                      .Take(fetchProductRequest.ProductPerPage); // then take only proucts starting from page 3 to add to the products

            }
            //The user is using filetering both category (selected)   and brand (selected)
            if (fetchProductRequest.CategorySlug != "all-categories" && fetchProductRequest.BrandSlug != "all-brands")
            {
                var filteredProducts = _productRepository.GetAllProducts()
                    .Where(products => products.ProductStatus == ProductStatus.Active &&
                                       products.Category.Slug == fetchProductRequest.CategorySlug &&
                                       products.Brand.Slug == fetchProductRequest.BrandSlug);

                prouductCount = filteredProducts.Count();
                products = filteredProducts.Skip((fetchProductRequest.PageNumber - 1) * fetchProductRequest.ProductPerPage)
                                                              .Take(fetchProductRequest.ProductPerPage);
            }
            //The user is using filetering only using category (selected)   and not brand (not selected)
            if(fetchProductRequest.CategorySlug != "all-categories" && fetchProductRequest.BrandSlug == "all-brands")
            {
                var filteredProducts = _productRepository.GetAllProducts()
                                         .Where(products => products.ProductStatus == ProductStatus.Active &&
                                                            products.Category.Slug == fetchProductRequest.CategorySlug);
                prouductCount = filteredProducts.Count();
                products = filteredProducts.Skip((fetchProductRequest.PageNumber - 1) * fetchProductRequest.ProductPerPage)
                    .Take(fetchProductRequest.ProductPerPage);
            }

            //The user is using filetering only using brand (selected)   and not category (not selected)
            if (fetchProductRequest.CategorySlug == "all-categories" && fetchProductRequest.BrandSlug != "all-brands")
            {
                var filteredProducts = _productRepository.GetAllProducts()
                                       .Where(products => products.ProductStatus == ProductStatus.Active &&
                                                          products.Brand.Slug == fetchProductRequest.BrandSlug);
                prouductCount = filteredProducts.Count();
                products = filteredProducts.Skip((fetchProductRequest.PageNumber - 1) * fetchProductRequest.ProductPerPage)
                                            .Take(fetchProductRequest.ProductPerPage);
            }


            var totalPages = (int)Math.Ceiling((decimal)prouductCount / fetchProductRequest.ProductPerPage);
            int[] pages = Enumerable.Range(1, totalPages).ToArray();
            var productDtos = _messageMapper.MapToProductDtos(products);
            var fetchProductResponse = new FetchOrdersResponse()
            {
                ProductPerPage = fetchProductRequest.ProductPerPage,
                Products = productDtos,
                HasNextPages = (fetchProductRequest.PageNumber < totalPages),
                HasPreviousPages = (fetchProductRequest.PageNumber > 1),
                CurrentPage = fetchProductRequest.PageNumber,
                Pages = pages
            };
            return fetchProductResponse;
        }




    }
}
