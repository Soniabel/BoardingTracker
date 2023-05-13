using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.SeniorityLevels.Commands.DeleteSeniorityLevel
{
    public class DeleteSeniorityLevelHandler : IRequestHandler<DeleteSeniorityLevelRequest, int>
    {
        private readonly DBBoardingTrackerContext _context;

        public DeleteSeniorityLevelHandler(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteSeniorityLevelRequest request, CancellationToken cancellationToken)
        {
            var seniorityLevel = await _context.SeniorityLevels.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (seniorityLevel is null)
            {
                throw new NotFoundException(nameof(SeniorityLevel), request.Id);
            }

            _context.SeniorityLevels.Remove(seniorityLevel);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
