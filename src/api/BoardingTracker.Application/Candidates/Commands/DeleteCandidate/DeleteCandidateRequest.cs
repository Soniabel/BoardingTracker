using MediatR;

namespace BoardingTracker.Application.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
