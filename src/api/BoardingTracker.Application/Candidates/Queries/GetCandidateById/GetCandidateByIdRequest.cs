using BoardingTracker.Application.Candidates.Models;
using MediatR;

namespace BoardingTracker.Application.Candidates.Queries.GetCandidateById
{
    public class GetCandidateByIdRequest : IRequest<CandidateModel>
    {
        public Guid Id { get; set; }
    }
}
