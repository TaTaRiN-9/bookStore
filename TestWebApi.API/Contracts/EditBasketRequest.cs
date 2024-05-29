using System.ComponentModel.DataAnnotations;

namespace TestWebApi.API.Contracts
{
    public record EditBasketRequest(
        [Required] string EmailUser,
        [Required] List<book> books
    );

    public record book(
        [Required] int id,
        [Required] int quantity
        );
}
