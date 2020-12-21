using BmesRestApi.Messages.DataTransferObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.Product
{
    public class UpdateProductRequest
    {
        public ProductDto product { get; set; }
        public int Id { get; set; }
    }
}
