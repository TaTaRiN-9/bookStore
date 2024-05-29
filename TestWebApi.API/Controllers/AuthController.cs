using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.API.Contracts;
using TestWebApi.Core.Abstractions;
using TestWebApi.Core.Models;
using TestWebApi.Application.Services;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TestWebApi.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtServices _jwtServices;
        public AuthController(IUserRepository userRepository, IJwtServices jwtServices)
        {
            _userRepository = userRepository;
            _jwtServices = jwtServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsersRegister usersRegister)
        {
            // исправить многое нужно, а именно результат создания, успешно или нет
            var user = new User(
                usersRegister.Name,
                usersRegister.Email,
                BCrypt.Net.BCrypt.HashPassword(usersRegister.Password)
            );

            var checkUser = await _userRepository.GetByEmail(usersRegister.Email);

            if (checkUser != null) return BadRequest("Пользователь с таким email уже существует!");

            var userResult = await _userRepository.Create(user);

            string jwtToken = _jwtServices.Generate(userResult);

            var response = new
            {
                user = userResult,
                access_token = jwtToken
            };

            return Created("success", response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsersLogin usersLogin)
        {
            User? userDB = await _userRepository.GetByEmail(usersLogin.Email);

            if (userDB == null) return BadRequest(new { message = "Неверный логин или пароль" });

            if (!BCrypt.Net.BCrypt.Verify(usersLogin.Password, userDB.Password))
                return BadRequest(new { message = "Неверный логин или пароль" });

            string jwtToken = _jwtServices.Generate(userDB);

            var user = new UserResponse(userDB.Id, userDB.Name, userDB.Email);

            var response = new
            {
                user = user,
                access_token = jwtToken
            };

            return Ok(response);
        }
    }
}
