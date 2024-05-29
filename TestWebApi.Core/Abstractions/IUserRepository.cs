using TestWebApi.Core.Models;

namespace TestWebApi.Core.Abstractions
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User>? GetByEmail(string email);
    }
}
