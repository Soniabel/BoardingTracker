using BoardingTracker.Application.Users.Models;
using MediatR;

namespace BoardingTracker.Application.Users.Commands.UpdateUser
{
    public class UpdateUserRequest : IRequest<UserModel>
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;
    }
}
