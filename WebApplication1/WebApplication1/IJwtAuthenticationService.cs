using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1
{
    public interface IJwtAuthenticationService
    {
        User Authenticate(string email, string password);
        string GenerateToken(string secret, List<Claim> claims);
    }
}
