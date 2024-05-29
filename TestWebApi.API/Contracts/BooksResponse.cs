namespace TestWebApi.API.Contracts
{
    // объект, который мы возвращаем на фронт.
    // То есть это именно то, что получит фронт.

    // Это необходимо для того, чтобы возвращать не все поля,
    // а только те, которые нужны
    public record BooksResponse(
        int Id, 
        string Title, 
        string Description, 
        decimal Price);
}
