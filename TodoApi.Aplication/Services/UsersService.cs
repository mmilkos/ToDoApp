using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain.Dtos;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Aplication.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _authentication;
        public UsersService(IUsersRepository usersRepository, IConfiguration configuration)
        {
            _usersRepository = usersRepository;
            _authentication = configuration.GetSection("Authentication");
        }

        public async Task<User> RegisterAsync(string userName, string password)
        {
            using var hmac = new HMACSHA512();
            var user = new User()
            {
                Name = userName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            await _usersRepository.RegisterAsync(user);

            return user;
        }

        public bool CheckIfUserAlreadyExists(string userName) 
        {
           return _usersRepository.CheckIfUserAlreadyExists(userName);
        }

        public async Task<User> LoginAsync(LoginFormDto userLoginData)
        {
            var user = await _usersRepository.GetUserByNameAsync(userLoginData.Name.ToLower());
            bool corectPassword = CheckPassword(user, userLoginData);
            
            if (corectPassword)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        private bool CheckPassword(User user, LoginFormDto userLoginData)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginData.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) 
                { 
                    return false; 
                }
            }
            return true;
        }

        public string GenerateJwt(User user)
        {
            string jwtIssuer = _authentication.GetValue<string>("JwtIssuer");
            string jwtKey = _authentication.GetValue<string>("JwtKey");
            int jwtExpireDays = _authentication.GetValue<int>("JwtExpireDays");
           
            var claims = new List<Claim>() 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Name}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(jwtExpireDays);

            var token = new JwtSecurityToken(
                jwtIssuer, 
                jwtIssuer, 
                claims, 
                expires: expires, 
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
