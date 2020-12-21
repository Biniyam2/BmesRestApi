using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Response.User
{
    public class LoginResponse : ResponseBase
    {
        public string Token { get; set; }
    }
}
