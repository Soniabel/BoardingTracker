using MediatR;

namespace BoardingTracker.Application.Users.Commands.DeleteUser
{
    public class DeleteUserRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
