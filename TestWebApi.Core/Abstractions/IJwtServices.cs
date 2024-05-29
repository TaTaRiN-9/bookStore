using TestWebApi.Core.Models;

namespace TestWebApi.Application.Services
{
    public interface IJwtServices
    {
        string Generate(User user);
    }
}