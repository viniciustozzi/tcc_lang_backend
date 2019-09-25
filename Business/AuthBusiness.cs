using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TccLangBackend.DB.DB;
using TccLangBaekend.DB;

namespace TccLangBackend.DB.Business
{
    public class AuthBusiness
    {
        private readonly IConfiguration _configuration;
        private readonly TccDbContext _dbContext;

        public AuthBusiness(IConfiguration configuration, TccDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<TokenResponse> Authenticate(AuthRequest authRequest)
        {
            var user = await FindByUsernameAsync(authRequest.Username);

            if (user == null)
                throw new ArgumentException($"User with username {authRequest.Username} does not exist");

            if (!VerifyPasswordHash(authRequest.Password, user.PasswordHash, user.PasswordSalt))
                throw new ArgumentException("Invalid password");

            var token = CreateJwtToken(user);

            return new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = token.ValidTo
            };
        }

        public Task Register(RegisterRequest request)
        {
            CreatePasswordHash(request.Password, out var hash, out var salt);
            var user = new User
            {
                Fullname = request.Fullname,
                Username = request.Username,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            _dbContext.Users.Add(user);

            return _dbContext.SaveChangesAsync();
        }

        private Task<User> FindByUsernameAsync(string payloadUsername)
        {
            return _dbContext.Users.FirstOrDefaultAsync(x => x.Username == payloadUsername);
        }

        public static UserToken GetTokenFromContext(HttpContext request)
        {
            var rawToken = request.Request.Headers["Authorization"][0].Substring(7);

            return DeserializeToken(rawToken);
        }

        public static UserToken DeserializeToken(string token)
        {
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var id = int.Parse(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value);
//            var roles = jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
            return new UserToken
            {
                UserId = id
//                Roles = roles
            };
        }

        public JwtSecurityToken CreateJwtToken(User user) =>
            new JwtSecurityToken(
                _configuration["SiteUrl"],
                _configuration["SiteUrl"],
                GetUserClaims(user),
                expires: DateTime.UtcNow.AddMonths(6),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"])),
                    SecurityAlgorithms.HmacSha256)
            );

        private static IEnumerable<Claim> GetUserClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

//            claims.AddRange(user.Roles.Select(r => new Claim(ClaimTypes.Role, r)));

            return claims;
        }

        public static void CreatePasswordHash(string rawPassword, out byte[] hashedPassword, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
            }
        }

        public static bool VerifyPasswordHash(string rawPassword, byte[] storedHash, byte[] storedSalt)
        {
            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
                for (var i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != storedHash[i])
                        return false;
            }

            return true;
        }
    }

    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
    }

    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class UserToken
    {
        public int UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}