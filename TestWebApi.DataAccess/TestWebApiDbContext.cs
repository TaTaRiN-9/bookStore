using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.CompilerServices;
using TestWebApi.DataAccess.Entities;

namespace TestWebApi.DataAccess
{
    public class TestWebApiDbContext : DbContext
    {
        public TestWebApiDbContext(DbContextOptions<TestWebApiDbContext> options)
            : base(options)
        {

        }

        public DbSet<BookEntity> books { get; set; } = null!;
        public DbSet<UserEntity> users { get; set; } = null!;
        public DbSet<OrderEntity> orders { get; set; } = null!;
        public DbSet<BasketEntity> basket { get; set; } = null!;
        public DbSet<GenreEntity> genres { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}