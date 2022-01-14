using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IMapper _autoMapper;
        private AdventureWorksLT2019Context context;
        public ProjectController(IMapper Mapper)
        {
            context = new AdventureWorksLT2019Context();
            _autoMapper = Mapper;
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public List<User> Get()
        {
            var userlist = context.Customers.ToList();
            var user = new User("tototr");
            var userDto = new UserDTO();
            userDto.Name = "posloap";
            var users = new List<User>() { new User("toti"), new User("toto") };
            var mapo= _autoMapper.Map<List<UserDTO>>(userlist);
            var map = _autoMapper.Map<UserDTO>(user);
            var map2 = _autoMapper.Map<User>(userDto);
            var map3 = _autoMapper.Map<List<UserDTO>>(users);



            return users;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
