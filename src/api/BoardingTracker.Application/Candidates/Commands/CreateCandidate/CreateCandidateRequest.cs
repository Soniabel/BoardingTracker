using BoardingTracker.Application.Candidates.Models;
using MediatR;

namespace BoardingTracker.Application.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateRequest : IRequest<CandidateModel>
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Biography { get; set; }

        public string ResumeUrl { get; set; }

        public Guid UserId { get; set; }
    }

}
