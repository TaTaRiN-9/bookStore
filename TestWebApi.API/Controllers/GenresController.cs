using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApi.DataAccess;

namespace TestWebApi.API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly TestWebApiDbContext _context;

        public GenresController(TestWebApiDbContext context)
        {
            _context = context; 
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetGenres()
        {
            return Ok(await _context.genres.ToListAsync());
        }
    }
}
