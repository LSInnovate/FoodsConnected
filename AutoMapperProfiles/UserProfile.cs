using AutoMapper;
using FoodsConnected.Contexts.UserInfo.Entities;
using FoodsConnected.Models;

namespace FoodsConnected.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForCreationDTO, UserEntity>();
            CreateMap<UserEntity, UserDTO>();
            CreateMap<UserForUpdateDTO, UserEntity>();
        }
    }
}
