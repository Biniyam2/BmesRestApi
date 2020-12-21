using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmesRestApi.Infrastructure
{
    public static class AuthExtensions
    {
        public static ServiceCollection AddJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(key: "Authsettings"); // calling the Authsettings that is in appsetting.json
            var authSettings = settings.Get<AuthSettings>(); // and then connecting it to AuthSettings class in Infrastructure Folder

            services.Configure<AuthSettings>(settings); // then adding the class to services
            var key = Encoding.ASCII.GetBytes(authSettings.Key); // then convert the key in the class to Byte arrays
            services.AddAuthentication();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                   
                });


            return (ServiceCollection)services;
        }
    }
}
