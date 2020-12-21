using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.DataTransferObjects.Shared
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserNameDto { get; set; }
        public string NameDto { get; set; }
    }
}
