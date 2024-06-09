using TestWebApi.Core.Models;

namespace TestWebApi.Application.Services
{
    public interface IGenresServices
    {
        Task<List<Genre>> GetAllGenres();
    }
}