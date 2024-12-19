using GameApi.Services;
using GameApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using User.Models;
using MongoDB.Driver;

namespace GameApi.Services
{
    public class UserServices : IUserServices
    {
        // private readonly UserContext _context;
        private readonly IMongoCollection<UserModel> _context;
        private readonly IProjectService _projectServices;

        public UserServices(MongoDbContext context, IProjectService projectService)
        {
            _context = context.Users;
            _projectServices = projectService;
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            return await _context.Find(user => true).ToListAsync();
        }

        public async Task<UserModel> GetUserById(long id)
        {
            return await _context.Find(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<UserModel> CreateUser(UserDto user)
        {
            var userModel = new UserModel
            {
                Username = user.Username,
                Password = user.Password,
                Level = 0,
                LevelId = 0
            };
            await _context.InsertOneAsync(userModel);

            return userModel;
        }

        // public async Task<long> UpdateUserById(long id, UserDto user)
        // {
        //     await _context.ReplaceOneAsync(u => u.Id == id, user);
        //     return id;
        // }

        // public async Task<long> DeleteUserById(long id)
        // {
        //     await _context.DeleteOneAsync(u => u.Id == id);
        //     return id;
        // }

        // private bool UserModelExists(long id)
        // {
        //     return (_context.UserModels?.Any(e => e.Id == id)).GetValueOrDefault();
        // }

        // public async Task<UserModel> UpdateUserLevel(long userId, long projectId, float timeTaken)
        // {
        //     var existingUser = await _context.UserModels.FindAsync(userId);

        //     if (existingUser == null)
        //     {
        //         throw new KeyNotFoundException($"User with ID {userId} was not found.");
        //     }

        //     ProjectDto project = await _projectServices.GetProjectDtoById(projectId);

        //     int levingUp = LevingUp.CalculateLevelUp(project.TimeRequired, timeTaken, project.Difficulty);
        //     existingUser.Level = levingUp;

        //     await _context.SaveChangesAsync();
        //     return existingUser;
        // }
    }
}