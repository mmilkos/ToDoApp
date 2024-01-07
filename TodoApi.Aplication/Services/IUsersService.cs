using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain.Dtos;
using TodoApi.Domain.Entities;

namespace TodoApi.Aplication.Services
{
    public interface IUsersService
    {
        public Task<User> RegisterAsync(string userName, string password);
        public Task<User> LoginAsync(LoginFormDto loginDto);
        public bool CheckIfUserAlreadyExists(string name);
        public string GenerateJwt(User user);

    }
}
