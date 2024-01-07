using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain.Dtos;
using TodoApi.Domain.Entities;

namespace TodoApi.Aplication.Mappings
{
    public class UserTaskMappingProfile : Profile
    {
        public UserTaskMappingProfile() 
        {
            CreateMap<TaskFormDto, UserTask>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<UserTask, TaskDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
 
        }
    }
}
