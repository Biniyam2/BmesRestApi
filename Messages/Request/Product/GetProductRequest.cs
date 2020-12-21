using BmesRestApi.Messages.DataTransferObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.Product
{
    public class GetProductRequest
    {
        public long Id{ get; set; }
    }
}
