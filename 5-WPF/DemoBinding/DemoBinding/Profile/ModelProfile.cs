using DemoBinding.Entities;
using DemonBinding.Models;

namespace DemoBinding.Profile
{
    public class ModelProfile : AutoMapper.Profile
    {
        public ModelProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap(); 
        }
    }
}
