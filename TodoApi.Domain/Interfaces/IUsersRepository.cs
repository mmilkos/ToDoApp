using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Interfaces
{
    public interface IUsersRepository
    {
        public Task RegisterAsync(User user);
        public Task<User> GetUserByNameAsync(string name);

        public bool CheckIfUserAlreadyExists(string name);

    }
}
