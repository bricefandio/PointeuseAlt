using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly List<User> _users = new List<User>(); //ici le _de user
        {
            new User
            {
                Id = 1,
                Username = "admin1",
                Email = "admin1@test.com,
                Password = "PwdAdmin1"
            
        
public User Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public string GenerateToken(string secret, List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)); //ici
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

            new User
            {
                Id = 2,
                Username = "user1",
                Email = "user1@test.com,
                Password = "PwdUser1"

            }
        };
        public User Authenticate(string email, string password)
        {
    return Users.Where(u => u.Email.ToUpper().Equals(email.ToUpper())
        && u.Password.Equals(password)).FirstOrDefault();
        }
    }
}
