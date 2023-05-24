using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IConfiguration _config;
        public AuthenticationController(IJwtAuthenticationService JwtAuthenticationService, IConfiguration config)
        {
            _jwtAuthenticationService = JwtAuthenticationService;
            _config = config;
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody]LoginModel model)
        {
            var user = _jwtAuthenticationService.Authenticate(model.Email, model.Password);
            if (user != null) 
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                };
                var token = _jwtAuthenticationService.GenerateToken(_config["jwt:Key"], claims);
            }
            return Unauthorized();
        }
    }
}
