﻿namespace TestWebApi.DataAccess.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
