using Microsoft.AspNetCore.Mvc;
using TestWebApi.API.Contracts;
using TestWebApi.Core.Models;
using TestWebApi.Application.Services;

namespace TestWebApi.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly IJwtServices _jwtServices;
        public AuthController(IJwtServices jwtServices, IAuthServices authServices)
        {
            _jwtServices = jwtServices;
            _authServices = authServices;
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

            var checkUser = await _authServices.GetUserByEmail(user.Email);

            if (checkUser != null) return BadRequest("Пользователь с таким email уже существует!");

            var userResult = await _authServices.Add(user);

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
            User? userDB = await _authServices.GetUserByEmail(usersLogin.Email);

            if (userDB == null) return BadRequest(new { message = "Неверный логин или пароль" });

            if (!_authServices.CheckPassword(usersLogin.Password, userDB.Password))
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
