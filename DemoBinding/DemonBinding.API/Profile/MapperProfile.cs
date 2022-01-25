using DemoBinding.Dtos;
using DemoBinding.Entities;

namespace DemonBinding.API.Profile
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity,UserDto>().ReverseMap();
        }
    }
}
