using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.DataAccess.Entities;

namespace TestWebApi.DataAccess.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            // первичный ключ
            builder.HasKey(g => g.Id);

            // уникальное имя
            builder.HasIndex(g => g.Name).IsUnique();

            // инициализация исходными данными
            builder.HasData(
                new GenreEntity { Id = 1, Name = "Фантастика"},
                new GenreEntity { Id = 2, Name = "Фэнтези" },
                new GenreEntity { Id = 3, Name = "Приключения" },
                new GenreEntity { Id = 4, Name = "Драма" },
                new GenreEntity { Id = 5, Name = "Мелодрама" },
                new GenreEntity { Id = 6, Name = "Роман" },
                new GenreEntity { Id = 7, Name = "Детектив" }
            );
        }
    }
}
