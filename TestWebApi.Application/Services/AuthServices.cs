using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Core.Abstractions;
using TestWebApi.Core.Models;
using BCrypt.Net;

namespace TestWebApi.Application.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IUserRepository _userRepository;
        public AuthServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User>? GetUserByEmail(string email)
        {
            var userEntity = await _userRepository.GetByEmail(email);

            if (userEntity == null) return null;

            return userEntity;
        }

        public bool CheckPassword(string password, string passwordDB)
        {
            if (!BCrypt.Net.BCrypt.Verify(password, passwordDB))
            {
                return false;
            }
            return true;
        }

        public async Task<User> Add(User user)
        {
            return await _userRepository.Create(user);
        }
    }
}
