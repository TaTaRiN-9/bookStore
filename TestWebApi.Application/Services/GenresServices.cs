using TestWebApi.Core.Models;
using TestWebApi.DataAccess.Repository;

namespace TestWebApi.Application.Services
{
    public class GenresServices : IGenresServices
    {
        private readonly IGenreRepository _genreRepository;

        public GenresServices(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            return await _genreRepository.GetAll();
        }
    }
}
