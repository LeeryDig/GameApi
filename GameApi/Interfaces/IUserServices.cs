using User.Models;

namespace GameApi.Services
{
    public interface IUserServices
    {
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetUserById(long id);
        Task<UserModel> CreateUser(UserDto userModel);
        // Task<long> UpdateUserById(long id, UserDto userModel);
        // Task<UserModel> UpdateUserLevel(long userId, long projectId, float timeTaken);
        // Task<long> DeleteUserById(long id);
    }
}