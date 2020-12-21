using BmesRestApi.Messages.DataTransferObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.Category
{
    public class CreateCategoryRequest
    {
        public CategoryDto Category { get; set; }
    }
}
