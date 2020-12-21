using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.DataTransferObjects.Product
{
    public class ProductDto : Shared.BaseDto
    {
        public string NameDto { get; set; }
        public string SlugDto { get; set; }
        public string DescriptionDto { get; set; }
        public string MetaDescriptionDto { get; set; }
        public string MetaKeywordsDto { get; set; }
        public string SKUDto { get; set; }
        public string ModelDto { get; set; }
        public decimal PriceDto { get; set; }
        public decimal SalePriceDto { get; set; }
        public decimal OldPriceDto { get; set; }
        public string ImageUrlDto { get; set; }
        public int QuantityInStockDto { get; set; }
        public bool IsBestsellerDto { get; set; }
        public bool IsFeaturedDto { get; set; }
        public long CategoryIdDto { get; set; }
        public long BrandIdDto { get; set; }
        public int ProductStatusDto { get; set; }
    }
}
