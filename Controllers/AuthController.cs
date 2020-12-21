using BmesRestApi.Messages.Request.User;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BmesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost(template: "register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var registerResponse = await _authService.RegisterAsync(request);
            if (registerResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                return BadRequest(registerResponse);
            }
            return Ok(registerResponse);
        }
        //[HttpPost(template: "register")]
        //public async Task<IActionResult> LogIn(LoginRequest request)
        //{
        //    var loginResponse = await _authService.LoginAsync(request);
        //    if (loginResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
        //    {
        //        return BadRequest(loginResponse);
        //    }
        //    return Ok(loginResponse);
        //}
    }
}
