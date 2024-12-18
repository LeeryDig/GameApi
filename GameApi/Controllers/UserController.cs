using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<List<UserModel>>> GetUserModels()
        {
            var users = await _services.GetAllUser();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserModel(long id)
        {
            var users = await _services.GetUserById(id);
            return Ok(users);
        }

        // PUT: api/User/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutUserModel(long id, UserDto user)
        // {
        //     try
        //     {
        //         var result = await _services.UpdateUserById(id, user);
        //         return base.CreatedAtAction(nameof(GetUserModels), result);
        //     }
        //     catch (InvalidOperationException ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUserModel(UserDto user)
        {
            try
            {
                var createdUser = await _services.CreateUser(user);
                return CreatedAtAction(nameof(GetUserModels), createdUser);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/User/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteUserModel(long id)
        // {
        //     try
        //     {
        //         var user = await _services.DeleteUserById(id);
        //         return CreatedAtAction(nameof(GetUserModels), user);
        //     }
        //     catch (InvalidOperationException ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }

        // [HttpPut("Level")]
        // public async Task<IActionResult> PutUserLevel(long userId, long projectId, float timeTaken)
        // {
        //     try
        //     {
        //         var result = await _services.UpdateUserLevel(userId, projectId, timeTaken);
        //         return base.CreatedAtAction(nameof(GetUserModels), result);
        //     }
        //     catch (InvalidOperationException ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }
    }
}
