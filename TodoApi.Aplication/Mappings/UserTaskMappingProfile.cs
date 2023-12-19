using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Domain;

namespace TodoApi.Aplication.Mappings
{
    public class UserTaskMappingProfile : Profile
    {
        public UserTaskMappingProfile() 
        {
            CreateMap<FormModelDto, UserTask>()
            .ForMember(dest => dest.Id, opt=> opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
 
        }
    }
}
