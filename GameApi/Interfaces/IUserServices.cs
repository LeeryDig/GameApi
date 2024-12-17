using User.Models;

namespace GameApi.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserModel>> GetAllUser();
        Task<IEnumerable<UserModel>> GetUserById(long id);
        Task<UserModel> CreateUser(UserDto userModel);
        Task<long> UpdateUserById(long id, UserDto userModel);
        Task<UserModel> UpdateUserLevel(long userId, long projectId, float timeTaken, int difficulty);
        Task<long> DeleteUserById(long id);
    }
}