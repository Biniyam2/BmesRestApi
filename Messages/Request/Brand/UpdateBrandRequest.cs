using BmesRestApi.Messages.DataTransferObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.Brand
{
    public class UpdateBrandRequest
    {
        public long Id { get; set; }
        public BrandDto Brand { get; set; }
    }
}
