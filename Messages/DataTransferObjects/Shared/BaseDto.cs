using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.DataTransferObjects.Shared
{
    public class BaseDto 
    {
        public long IdDto { get; set; }
        public DateTimeOffset CreatedDateDto { get; set; }
        public DateTimeOffset ModifiedDateDto { get; set; }
        public bool IsDeletedDto { get; set; }
    }
}
