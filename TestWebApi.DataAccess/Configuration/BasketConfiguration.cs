using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.DataAccess.Entities;

namespace TestWebApi.DataAccess.Configuration
{
    public class BasketConfiguration : IEntityTypeConfiguration<BasketEntity>
    {
        public void Configure(EntityTypeBuilder<BasketEntity> builder)
        {
            // первичный ключ
            builder.HasKey(b => b.Id);

            // уникальное значения для поля emailUser
            builder.HasIndex(b => b.EmailUser).IsUnique();
        }
    }
}
