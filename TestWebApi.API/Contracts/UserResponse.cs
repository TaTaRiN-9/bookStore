namespace TestWebApi.API.Contracts
{
    public record UserResponse(
        int Id, 
        string? Name,
        string Email
    );
}
