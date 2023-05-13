using MediatR;

namespace BoardingTracker.Application.Users.Commands.DeleteUser
{
    public class DeleteUserRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
