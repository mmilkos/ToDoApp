using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Aplication.Services
{
    public class TodoApiService : ITodoApiService
    {
        private readonly ITodoApiRepository _todoApiRepository;
        private readonly IMapper _mapper;
        public TodoApiService(ITodoApiRepository todoApiRepository, IMapper mapper)
        {
            _todoApiRepository = todoApiRepository;
            _mapper = mapper;
        }

        public async Task<UserTask> AddTaskAsync(FormModelDto taskJson)
        {

            var task = _mapper.Map<Domain.UserTask>(taskJson);
            return _mapper.Map<Domain.UserTask>(await _todoApiRepository.AddTaskAsync(task));
        }

        public async Task<IEnumerable<UserTask>> GetAllTasksAsync()
        {
            var userTasks = await _todoApiRepository.GetAllTasksAsync();
            return userTasks;
        }
    }
}
