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
using TodoApi.Domain.Dtos;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Aplication.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _todoApiRepository;
        private readonly IMapper _mapper;
        public TasksService(ITasksRepository todoApiRepository, IMapper mapper)
        {
            _todoApiRepository = todoApiRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> AddTaskAsync(TaskFormDto taskJson)
        {

            var task = _mapper.Map<UserTask>(taskJson);
            return _mapper.Map<TaskDto>(await _todoApiRepository.AddTaskAsync(task));
        }

        public async Task ChangeStatusAsync(int id)
        {
            await _todoApiRepository.ChangeStatusAsync(id);
        }

        public bool CheckIfTaskExistsById(int id)
        {
            bool result = _todoApiRepository.CheckIfObjectExistsById(id);
            return result;
        }

        public async Task DeleteTaskAsync(int id)
        {
           await _todoApiRepository.DeleteTaskAsync(id);
        }

        public async Task<IEnumerable<Domain.Entities.UserTask>> GetAllTasksAsync()
        {
            var userTasks = await _todoApiRepository.GetAllTasksAsync();
            return userTasks;
        }
    }
}
