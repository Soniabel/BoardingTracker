using BoardingTracker.Application.Users.Models;
using MediatR;

namespace BoardingTracker.Application.Users.Queries.GetUserById
{
    public class GetUserByIdRequest : IRequest<UserModel>
    {
        public int Id { get; set; }
    }
}
