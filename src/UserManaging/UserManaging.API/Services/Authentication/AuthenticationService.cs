using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UserManaging.API.Infrastructure.Configuration;

namespace UserManaging.API.Services.Authentication
{
    public interface IAuthenticationService
    {
        string Authenticate(UserLogin userLogin);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Test User", Username = "test", Password = "test" }
        };
        private readonly AppSettings _appSettings;

        public AuthenticationService(AppSettings appSettings) => 
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));

        public string Authenticate(UserLogin userLogin)
        {
            var user = _users.SingleOrDefault(x => x.Username == userLogin.Username && x.Password == userLogin.Password);

            if (user == null) return null;

            var token = GenerateJwtToken(user);

            return token;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.BearerToken.ServerSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.BearerToken.Issuer,
                Audience = _appSettings.BearerToken.Audience,
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.BearerToken.AccessTokenExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}