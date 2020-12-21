using BmesRestApi.Messages.DataTransferObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.Brand
{
    public class CreateBrandRequest
    {
        public BrandDto brand { get; set; }
    }
}
