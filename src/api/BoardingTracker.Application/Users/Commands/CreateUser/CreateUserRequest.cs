using BoardingTracker.Application.Users.Models;
using MediatR;

namespace BoardingTracker.Application.Users.Commands.CreateUser
{
    public class CreateUserRequest : IRequest<UserModel>
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;
    }
}
