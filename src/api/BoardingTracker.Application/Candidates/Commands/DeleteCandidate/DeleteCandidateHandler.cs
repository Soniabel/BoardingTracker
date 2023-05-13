using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateRequest, int>
    {
        private readonly DBBoardingTrackerContext _context;

        public DeleteCandidateHandler(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteCandidateRequest request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (candidate is null)
            {
                throw new NotFoundException(nameof(Candidate), request.Id);
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            return candidate.Id;
        }
    }
}
