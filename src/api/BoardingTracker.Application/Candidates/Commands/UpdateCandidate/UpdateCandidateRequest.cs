using BoardingTracker.Application.Candidates.Models;
using MediatR;

namespace BoardingTracker.Application.Candidates.Commands.UpdateCandidate
{
    public class UpdateCandidateRequest : IRequest<CandidateModel>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Biography { get; set; }

        public string ResumeUrl { get; set; } = null!;

        public Guid UserId { get; set; }
    }
}
