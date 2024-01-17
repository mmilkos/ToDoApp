using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        public async Task<TaskDto> AddTaskAsync(TaskFormDto taskJson, string name)
        {

            var task = _mapper.Map<UserTask>(taskJson);
            task.AuthorName = name;
            return _mapper.Map<TaskDto>(await _todoApiRepository.AddTaskAsync(task));
        }

        public async Task ChangeStatusAsync(int id)
        {
            await _todoApiRepository.ChangeStatusAsync(id);
        }

        public async Task DeleteTaskAsync(int id)
        {
           await _todoApiRepository.DeleteTaskAsync(id);
        }

        public async Task<IEnumerable<Domain.Entities.UserTask>> GetUserTasksAsync(string userName)
        {
            var userTasks = await _todoApiRepository.GetUserTasksAsync(userName);
            return userTasks;
        }

        public bool DoesTaskExist(int taskId)
        {
            bool result = _todoApiRepository.DoesTaskExist(taskId);
            return result;
        }

        public string GetUserNameFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            string userName = token.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;

            return userName;
        }

        public bool IsAuthorizationHeaderValid(IHeaderDictionary headers) 
        {

            if (!headers.ContainsKey("Authorization")) return false;
            var authHeader = headers["Authorization"].ToString();
            var authParts = authHeader.Split(' ');

            if (authParts.Length < 2) return false; 

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(authParts[1])) return false;

            return true;
        }
    }
}
