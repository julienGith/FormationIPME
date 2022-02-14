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
        private readonly ILogger<UsersController> _logger;

        public UsersController(IGenericRepository<UserEntity> userRepository, IMapper mapper, ILogger<UsersController> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>),200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                var usersEntity = _userRepository.GetAll();
                var dto = _mapper.Map<IEnumerable<UserDto>>(usersEntity);
                return Ok(dto);
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Une erreur est survenue");
                return StatusCode(500);
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            _logger.LogInformation($"Get method called with params: id={id}");
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
