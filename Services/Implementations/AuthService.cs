using BmesRestApi.Infrastructure;
using BmesRestApi.Repositories;
using BmesRestApi.Messages.Request.User;
using BmesRestApi.Messages.Response.User;
using BmesRestApi.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Renci.SshNet.Security;

namespace BmesRestApi.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AuthSettings _authSettings;
        private readonly IAuthRepository _authRespository;
        public AuthService(IAuthRepository authRespository, IOptions<AuthSettings> authSettings)
        {
            _authRespository = authRespository;
            _authSettings = authSettings.Value;
        }
        public async Task<FIndUserByEmailResponse> FIndAsync(FIndUserByEmailRequest request, CancellationToken cancellationToken = default) 
        {
            var user = await _authRespository.FindAsync(request.Email, cancellationToken);
            var findByEmail = new FIndUserByEmailResponse
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name
            };
            return findByEmail;
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest, CancellationToken cancellationToken = default)
        {
            var messages = new List<string>();
            var user = new User
            {
                Name = registerRequest.Name,
                Email = registerRequest.Email,
                UserName = registerRequest.Email
            };
            var result = await _authRespository.RegisterAsync(user, registerRequest.Password, cancellationToken);
            if(result.Succeeded)
            {
                messages.Add("User Registered");
                var registerResponse = new RegisterResponse
                {
                    Name = registerRequest.Name,
                    Email = registerRequest.Email,
                    StatusCode = System.Net.HttpStatusCode.Created,
                    Messages =messages
                    
                };
                return registerResponse;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    messages.Add(error.Description);
                }
                var registerResponse = new RegisterResponse
                {

                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Messages = messages

                };
                return registerResponse;
            }
            
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken = default)
        {
            var messages = new List<string>();
            var result = await _authRespository.LogInAsync(loginRequest.Email, loginRequest.Password, cancellationToken);
            if(result)
            {
                messages.Add("Logged in successfuly");
                var roles = await _authRespository.FindUserRolesAsync(loginRequest.Email, cancellationToken);
                var loginResponse = new LoginResponse
                {
                    Token = GenerateJwtToken(loginRequest, roles),
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Messages = messages
                };
                return loginResponse;
            }
            else
            {
                messages.Add("Your email or password is wrong");
              
                var loginResponse = new LoginResponse
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    Messages = messages
                };
                return loginResponse;
            }
        }

        private string GenerateJwtToken(LoginRequest loginRequest, IList<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, loginRequest.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));

            }
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSettings.Key);
            var secutiryTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_authSettings.ExpirasionInMinutes),
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key),
                 SecurityAlgorithms.HmacSha256Signature)
            };
           var securityToken = jwtSecurityTokenHandler.CreateToken(secutiryTokenDescriptor);
           return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}
