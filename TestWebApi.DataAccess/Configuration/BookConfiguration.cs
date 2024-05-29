using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.Core.Models;
using TestWebApi.DataAccess.Entities;

namespace TestWebApi.DataAccess.Configuration
{
    // можем добавлять конфигурации
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            // первичный ключ
            builder.HasKey(x => x.Id);

            // у поля title макс длина и обязательный параметр
            builder.Property(x => x.Title)
                .HasMaxLength(Book.MAX_LENGTH_TITLE)
                .IsRequired();

            builder.Property(b => b.Price).IsRequired();

            builder.HasData(
                new BookEntity
                {
                    Id = 1,
                    Title = "Гарри Поттер и тайная комната",
                    Description = "Черезвычайно захватывающее фэнтези. " +
                        "Прекрасно подойдет детям в подростковом возрасте!",
                    Price = 1900,
                    CategoryId = 2
                },
                new BookEntity
                {
                    Id = 2,
                    Title = "Гарри Поттер и узник Азкабана",
                    Description = "Черезвычайно захватывающее фэнтези. " +
                        "Прекрасно подойдет детям в подростковом возрасте!",
                    Price = 1900,
                    CategoryId = 2
                },
                new BookEntity
                {
                    Id = 3,
                    Title = "Мастер и Маргарита",
                    Description = "Одно из лучших произведений Михаила Булгакова, " +
                    "который является знаменитым писателем 20-ого века.",
                    Price = 1999,
                    CategoryId = 1
                },
                new BookEntity
                {
                    Id = 4,
                    Title = "Преступление и наказание",
                    Description = "Роман Фёдора Достоевского с криминальным сюжетом и " +
                    "глубокой религиозно-философской подоплёкой.",
                    Price = 1650,
                    CategoryId = 6
                },
                new BookEntity
                {
                    Id = 5,
                    Title = "Война и мир",
                    Description = "Роман Льва Толстого, в котором автор описывает " +
                    "человеческие жизни на фоне исторического события.",
                    Price = 2700,
                    CategoryId = 6
                },
                new BookEntity
                {
                    Id = 6,
                    Title = "Мертвые души",
                    Description = "Произведение Н.В.Гоголя.",
                    Price = 1200,
                    CategoryId = 7
                }
            );
        }
    }
}
