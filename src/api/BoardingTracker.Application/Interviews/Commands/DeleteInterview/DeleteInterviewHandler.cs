using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Interviews.Commands.DeleteInterview
{
    public class DeleteInterviewHandler : IRequestHandler<DeleteInterviewRequest, int>
    {
        private readonly DBBoardingTrackerContext _context;

        public DeleteInterviewHandler(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteInterviewRequest request, CancellationToken cancellationToken)
        {
            var interview = await _context.Interviews.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (interview is null)
            {
                throw new NotFoundException(nameof(Interview), request.Id);
            }

            _context.Interviews.Remove(interview);
            await _context.SaveChangesAsync(cancellationToken);

            return interview.Id;
        }
    }
}
