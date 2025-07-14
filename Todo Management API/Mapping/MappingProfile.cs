using AutoMapper;
using Todo_Management_API.DTOs;
using Todo_Management_API.Models;

namespace Todo_Management_API.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTodoDto , Todo>().ReverseMap();
            CreateMap<UpdateTodoDto, Todo>().ReverseMap();
            CreateMap<ReadTodoDto, Todo>().ReverseMap();

        }
    }
}
