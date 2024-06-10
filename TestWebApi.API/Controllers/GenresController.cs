using Microsoft.AspNetCore.Mvc;
using TestWebApi.Application.Services;

namespace TestWebApi.API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresServices _genresServices;

        public GenresController(IGenresServices genresServices)
        {
            _genresServices = genresServices;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetGenres()
        {
            return Ok(await _genresServices.GetAllGenres());
        }
    }
}
