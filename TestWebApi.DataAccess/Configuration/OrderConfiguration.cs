using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.DataAccess.Entities;

namespace TestWebApi.DataAccess.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            // первичный ключ
            builder.HasKey(o => o.Id);
        }
    }
}
