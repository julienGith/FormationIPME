using DemoBinding.Dtos;
using DemonBinding.Models;

namespace DemoBinding.Profile
{
    public class ModelProfile : AutoMapper.Profile
    {
        public ModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap(); 
        }
    }
}
