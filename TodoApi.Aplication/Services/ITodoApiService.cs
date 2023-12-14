using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain;

namespace TodoApi.Aplication.Services
{
    public interface ITodoApiService
    {
        Task<IEnumerable<UserTask>> GetAllTasksAsync();
    }
}
