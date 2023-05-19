﻿using BoardingTracker.Application.Auth.Abstract;

namespace BoardingTracker.Application.Auth.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string salt)
        {
            return BCrypt.Net.BCrypt.Verify(password, salt);
        }
    }
}
