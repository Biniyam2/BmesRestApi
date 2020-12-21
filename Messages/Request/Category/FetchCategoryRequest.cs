using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.Category
{
    public class FetchCategoryRequest
    {
        public int PageNumber { get; set; }
        public int CategoryPerPage { get; set; }
    }
}
