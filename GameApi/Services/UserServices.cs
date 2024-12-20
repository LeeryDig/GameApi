using User.Models;
using MongoDB.Driver;

namespace GameApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly IMongoCollection<UserModel> _context;

        public UserServices(MongoDbContext context)
        {
            _context = context.Users;
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            return await _context.Find(user => true).ToListAsync();
        }

        public async Task<UserModel> GetUserById(string id)
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
                Points = 0
            };
            await _context.InsertOneAsync(userModel);

            return userModel;
        }

        public async Task<UserModel> UpdateUserById(string id, UserDto userDto)
        {
            var filter = Builders<UserModel>.Filter.Eq(u => u.Id, id);

            var updatedUser = new UserModel
            {
                Username = userDto.Username,
                Password = userDto.Password,
            };
            await _context.ReplaceOneAsync(filter, updatedUser);
            return updatedUser;
        }

        public async Task<string> DeleteUserById(string id)
        {
            await _context.DeleteOneAsync(u => u.Id == id);
            return id;
        }
    }
}