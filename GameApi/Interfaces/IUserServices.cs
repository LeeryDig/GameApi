using User.Models;

namespace GameApi.Services
{
    public interface IUserServices
    {
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetUserById(string id);
        Task<UserModel> CreateUser(UserDto userDto);
        Task<UserModel> UpdateUserById(string id, UserDto userDto);
        Task<string> DeleteUserById(string id);
    }
}