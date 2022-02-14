using AutoMapper;
using DemoBinding.Dtos;
using DemonBinding.Models;

namespace DemoBinding.ApiData
{
    public class UserDataManager : ApiDataManager<UserModel, UserDto>
    {
        public UserDataManager(HttpClient client, IMapper mapper, string serverUrl) 
            : base(client, mapper, serverUrl, "/api/users")
        {
        }
    }
}
