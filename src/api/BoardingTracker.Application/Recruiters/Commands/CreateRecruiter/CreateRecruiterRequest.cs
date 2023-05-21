using BoardingTracker.Application.Recruiters.Models;
using MediatR;

namespace BoardingTracker.Application.Recruiters.Commands.CreateRecruiter
{
    public class CreateRecruiterRequest : IRequest<RecruiterModel>
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? ProfileImageUrl { get; set; }

        public string UserId { get; set; }
    }
}
