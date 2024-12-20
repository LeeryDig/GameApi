using GameApi.Services;
using Microsoft.AspNetCore.Mvc;
using User.Models;
using MongoDB.Driver;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<UserModel> _context;
        private readonly IUserServices _services;

        public UserController(MongoDbContext context, IUserServices services)
        {
            _context = context.Users;
            _services = services;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            try
            {
                var users = await _services.GetAllUser();
                return Ok(users);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(string id)
        {
            try
            {
                var users = await _services.GetUserById(id);
                return Ok(users);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserById(string id, UserDto user)
        {
            try
            {
                var result = await _services.UpdateUserById(id, user);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser(UserDto user)
        {
            try
            {
                var createdUser = await _services.CreateUser(user);
                return Ok(createdUser);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var user = await _services.DeleteUserById(id);
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
