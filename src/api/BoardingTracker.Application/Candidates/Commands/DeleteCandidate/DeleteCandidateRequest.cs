using MediatR;

namespace BoardingTracker.Application.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
