namespace TestWebApi.API.Contracts
{
    public class UsersRegister
    {
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
