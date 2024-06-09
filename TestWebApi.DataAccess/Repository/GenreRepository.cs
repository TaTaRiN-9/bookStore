using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataAccess.Entities;
using TestWebApi.Core.Models;

namespace TestWebApi.DataAccess.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly TestWebApiDbContext _db;

        public GenreRepository(TestWebApiDbContext db)
        {
            _db = db;
        }

        public async Task<List<Genre>> GetAll()
        {
            var genreEntity = await _db.genres.AsNoTracking().ToListAsync();

            List<Genre> genres = genreEntity
                .Select(genre => Genre.Create(genre.Id, genre.Name)).ToList();

            return genres;
        }
    }
}
