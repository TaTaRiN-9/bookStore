using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestWebApi.API.Contracts;
using TestWebApi.DataAccess;
using TestWebApi.DataAccess.Entities;
using Newtonsoft.Json;

namespace TestWebApi.API.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly TestWebApiDbContext _context;

        public BasketController(TestWebApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetBasketByName(string email)
        {
            var basket = await _context.basket.FirstOrDefaultAsync(b => b.EmailUser == email);

            if (basket == null)
            {
                basket = new BasketEntity
                {
                    EmailUser = email,
                    ListBook = "[]"
                };

                await _context.basket.AddAsync(basket);
                await _context.SaveChangesAsync();
            }

            // возвращаем книги, которые находятся в корзине у пользователя
            return Ok(basket.ListBook);
        }

        [HttpPost("edit-basket")]
        public async Task<IActionResult> EditBasket([FromBody] EditBasketRequest? editBasketRequest)
        {
            Console.WriteLine(editBasketRequest?.EmailUser + " +++ " + editBasketRequest?.books + " +++ ");
            BasketEntity? basketUser = await _context.basket.FirstOrDefaultAsync(b => b.EmailUser == editBasketRequest.EmailUser);

            Console.WriteLine(basketUser?.EmailUser + " ++++++++ +++++++ ");

            if (basketUser == null) return NotFound("Корзина для этого пользователя не сущетсвует");

            string booksBasketJson = JsonConvert.SerializeObject(editBasketRequest?.books);

            Console.WriteLine(booksBasketJson);
            basketUser.ListBook = booksBasketJson;

            _context.SaveChanges();

            return Ok(basketUser);
        }
    }
}
