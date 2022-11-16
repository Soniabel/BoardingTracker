using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.InterviewTypes.Commands.DeleteInterviewType
{
    public class DeleteInterviewTypeHandler : IRequestHandler<DeleteInterviewTypeRequest, int>
    {
        private readonly DBBoardingTrackerContext _context;

        public DeleteInterviewTypeHandler(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteInterviewTypeRequest request, CancellationToken cancellationToken)
        {
            var interviewType = await _context.InterviewTypes.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (interviewType is null)
            {
                throw new NotFoundException(nameof(InterviewType), request.Id);
            }

            _context.InterviewTypes.Remove(interviewType);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
