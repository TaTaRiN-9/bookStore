using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.DataAccess.Entities;

namespace TestWebApi.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(u => new { u.Email }).IsUnique();

            builder.Property(u => u.Password)
                .IsRequired();
        }
    }
}
