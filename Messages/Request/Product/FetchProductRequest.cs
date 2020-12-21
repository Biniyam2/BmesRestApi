using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.Product
{
    public class FetchProductRequest
    {
        public int PageNumber { get; set; }
        public int ProductPerPage { get; set; }
        public string CategorySlug { get; set; }
        public string BrandSlug { get; set; }

    }
}
