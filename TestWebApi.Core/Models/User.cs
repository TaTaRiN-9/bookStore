using System.Text.Json.Serialization;

namespace TestWebApi.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; }
        public string Email { get; } = null!;
        [JsonIgnore]
        public string Password { get; } = null!;

        public User(string? name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public User(int id, string? name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
