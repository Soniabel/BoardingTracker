using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.VacancyStatuses.Commands.DeleteVacancyStatus
{
    public class DeleteVacancyStatusHandler : IRequestHandler<DeleteVacancyStatusRequest, int>
    {
        private readonly DBBoardingTrackerContext _context;

        public DeleteVacancyStatusHandler(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteVacancyStatusRequest request, CancellationToken cancellationToken)
        {
            var vacancyStatus = await _context.VacancyStatuses.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vacancyStatus is null)
            {
                throw new NotFoundException(nameof(VacancyStatus), request.Id);
            }

            _context.VacancyStatuses.Remove(vacancyStatus);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
