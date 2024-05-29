using Microsoft.EntityFrameworkCore;
using TestWebApi.Core.Abstractions;
using TestWebApi.Core.Models;
using TestWebApi.DataAccess.Entities;

namespace TestWebApi.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TestWebApiDbContext _context;
        public UserRepository(TestWebApiDbContext context)
        {
            _context = context;
        }

        private int GetId()
        {
            return _context.users.ToList().Last().Id;
        }
        public async Task<User> Create(User user)
        {
            var userEntity = new UserEntity {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };

            await _context.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            user.Id = GetId();

            return user;
        }

        public async Task<User>? GetByEmail(string email)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) return null;

            User newUser = new(user.Id, user.Name, user.Email, user.Password);

            return newUser;
        }
    }
}
