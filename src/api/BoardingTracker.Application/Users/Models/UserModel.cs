﻿namespace BoardingTracker.Application.Users.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;
    }
}
