using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestWebApi.API.Contracts;
using TestWebApi.DataAccess;
using TestWebApi.DataAccess.Entities;

namespace TestWebApi.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly TestWebApiDbContext _context;

        public OrdersController(TestWebApiDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder([FromBody] EditBasketRequest editBasketRequest)
        {
            string bookBasketJson = JsonConvert.SerializeObject(editBasketRequest.books);

            OrderEntity order = new OrderEntity
            {
                EmailUser = editBasketRequest.EmailUser,
                Name = bookBasketJson
            };

            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }
    }
}
