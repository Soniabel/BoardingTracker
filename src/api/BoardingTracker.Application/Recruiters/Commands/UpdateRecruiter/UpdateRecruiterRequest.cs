using BoardingTracker.Application.Recruiters.Models;
using MediatR;

namespace BoardingTracker.Application.Recruiters.Commands.UpdateRecruiter
{
    public class UpdateRecruiterRequest : IRequest<RecruiterModel>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? ProfileImageUrl { get; set; }

        public Guid UserId { get; set; }
    }
}
