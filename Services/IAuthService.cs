using BmesRestApi.Messages.Request.User;
using BmesRestApi.Messages.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BmesRestApi.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest, CancellationToken cancellationToken = default);
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken = default);
    }
}
