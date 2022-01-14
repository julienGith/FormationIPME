using AutoMapper;
using TestAPI.Entities;

namespace TestAPI
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<User, UserDTO >().ReverseMap();
            CreateMap<Customer, UserDTO>().ForMember(dest=>dest.Name, src=> src.MapFrom(src=>src.FirstName));


        }
    }
}
