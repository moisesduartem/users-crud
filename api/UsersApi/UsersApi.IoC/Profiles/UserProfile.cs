using AutoMapper;
using UsersApi.Application.DTOs;
using UsersApi.Domain.Entities;

namespace UsersApi.IoC.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
