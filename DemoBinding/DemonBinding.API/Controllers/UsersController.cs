using AutoMapper;
using DemoBinding.Dtos;
using DemoBinding.Entities;
using DemoBinding.Persistance;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemonBinding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IGenericRepository<UserEntity> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            var usersEntity = _userRepository.GetAll();
            var dto = _mapper.Map<IEnumerable<UserDto>>(usersEntity);
            return Ok(dto); 
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDto user)
        {
            var entity = _mapper.Map<UserEntity>(user);
            _userRepository.Add(entity);

            //permet de retourner une 201 avec le lien de la nouvelle ressource dans le header location
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity); 
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
