using TestWebApi.Core.Models;

namespace TestWebApi.Application.Services
{
    public interface IAuthServices
    {
        Task<User> Add(User user);
        bool CheckPassword(string password, string passwordDB);
        Task<User>? GetUserByEmail(string email);
    }
}