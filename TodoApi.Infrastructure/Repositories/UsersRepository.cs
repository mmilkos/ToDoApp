using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;
using TodoApi.Infrastructure.Persistence;

namespace TodoApi.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ToDoAppDbContext _DbContext;
        public UsersRepository(ToDoAppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task RegisterAsync(User user)
        {
            _DbContext.Users.Add(user);
            await _DbContext.SaveChangesAsync();

        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            var user = await _DbContext.Users.SingleOrDefaultAsync(user => user.Name == name);
            return user;
        }

        public bool CheckIfUserAlreadyExists(string name)
        {
            bool exists = _DbContext.Users.Any(user => user.Name == name);
            return exists;
        }
    }
}
