using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Models.Shared
{
    public class User : IdentityUser
    {
        public string Name { get; set; } //full name

    }
}
