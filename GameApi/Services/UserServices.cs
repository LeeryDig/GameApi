using GameApi.Services;
using GameApi.Utils;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using User.Models;

namespace GameApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserContext _context;
        private readonly IProjectService _projectServices;

        public UserServices(UserContext context, IProjectService projectService)
        {
            _context = context;
            _projectServices = projectService;
        }

        public async Task<IEnumerable<UserModel>> GetAllUser()
        {
            if (_context.UserModels == null)
            {
                return Enumerable.Empty<UserModel>();
            }

            return await _context.UserModels.ToListAsync();
        }

        public async Task<IEnumerable<UserModel>> GetUserById(long id)
        {
            if (_context.UserModels == null)
            {
                return Enumerable.Empty<UserModel>();
            }
            var userModel = await _context.UserModels.FindAsync(id);

            if (userModel == null)
            {
                return Enumerable.Empty<UserModel>();
            }

            return await _context.UserModels.ToListAsync();
        }

        public async Task<UserModel> CreateUser(UserDto user)
        {
            var userModel = new UserModel
            {
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                Level = 0,
                LevelId = 0
            };
            _context.UserModels.Add(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        public async Task<long> UpdateUserById(long id, UserDto user)
        {
            var existingUser = await _context.UserModels.FindAsync(id);

            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }

            existingUser.Name = user.Name;
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;

            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<long> DeleteUserById(long id)
        {
            if (_context.UserModels == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }
            var userModel = await _context.UserModels.FindAsync(id);
            if (userModel == null)
            {
                throw new KeyNotFoundException($"User Not Found.");
            }

            _context.UserModels.Remove(userModel);
            await _context.SaveChangesAsync();

            return id;
        }

        private bool UserModelExists(long id)
        {
            return (_context.UserModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<UserModel> UpdateUserLevel(long userId, long projectId, float timeTaken)
        {
            var existingUser = await _context.UserModels.FindAsync(userId);

            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} was not found.");
            }

            ProjectDto project = await _projectServices.GetProjectDtoById(projectId);

            int levingUp = LevingUp.CalculateLevelUp(project.TimeRequired, timeTaken, project.Difficulty);
            existingUser.Level = levingUp;

            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}