﻿using BmesRestApi.Messages.DataTransferObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Response.Category
{
    public class DeleteCategoryResponse : ResponseBase
    {
        public CategoryDto Category { get; set; }
    }
}
