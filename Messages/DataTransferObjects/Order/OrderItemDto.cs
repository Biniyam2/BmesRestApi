using BmesRestApi.Messages.DataTransferObjects.Product;
using BmesRestApi.Messages.DataTransferObjects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.DataTransferObjects.Order
{
    public class OrderItemDto : BaseDto
    {
        public long OrderIdDto { get; set; }
        public long ProductIdDto { get; set; }
        public ProductDto ProductDto { get; set; }
        public int QuantityDto { get; set; }
    }
}
