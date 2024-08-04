
using Application.DTOs.Identity;
using AutoMapper;
using Infrastructure.Data.Identity.Models;

namespace Infrastructure.Data.Identity.Mapper
{
    public class InfrastactureProfile : Profile
    {
        public InfrastactureProfile()
        {
            CreateMap<User,UserDto>().ReverseMap();

        }
    }
}
