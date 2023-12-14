using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Domain.Interfaces
{
    public interface ITodoApiRepository
    {
        Task<IEnumerable<Domain.UserTask>> GetAllTasksAsync();
    }
}
