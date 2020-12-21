using BmesRestApi.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.DataTransferObjects.Product
{
    public class BrandDto : Shared.BaseDto
    {
        public string NameDto { get; set; }
        public string SlugDto { get; set; }
        public string DescriptionDto { get; set; }
        public string MetaDescriptionDto { get; set; }
        public string MetaKeywordsDto { get; set; }
        public int BrandStatusDto { get; set; }
    }
}
