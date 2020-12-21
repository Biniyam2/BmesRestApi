using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Response.User
{
    public class RegisterResponse : ResponseBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
