using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Recruiters.Commands.DeleteRecruiter
{
    public class DeleteRecruiterHandler : IRequestHandler<DeleteRecruiterRequest, int>
    {
        private readonly DBBoardingTrackerContext _context;

        public DeleteRecruiterHandler(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteRecruiterRequest request, CancellationToken cancellationToken)
        {
            var recruiter = await _context.Recruiters
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (recruiter is null)
            {
                throw new NotFoundException(nameof(Recruiter), request.Id);
            }

            _context.Recruiters.Remove(recruiter);
            await _context.SaveChangesAsync(cancellationToken);

            return recruiter.Id;
        }
    }
}
