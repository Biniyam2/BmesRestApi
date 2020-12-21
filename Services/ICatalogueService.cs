﻿using BmesRestApi.Messages.Request.Product;
using BmesRestApi.Messages.Response.Product;


namespace BmesRestApi.Services
{
    public interface ICatalogueService
    {
        FetchOrdersResponse FetchProducts(FetchProductRequest fetchProductRequest);
    }
}
