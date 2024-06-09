using TestWebApi.Core.Models;

namespace TestWebApi.DataAccess.Repository
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAll();
    }
}