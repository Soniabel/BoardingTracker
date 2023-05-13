using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.VacancyTypes.Commands.DeleteVacancyType
{
    public class DeleteVacancyTypeHandler : IRequestHandler<DeleteVacancyTypeRequest, int>
    {
        private readonly DBBoardingTrackerContext _context;

        public DeleteVacancyTypeHandler(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteVacancyTypeRequest request, CancellationToken cancellationToken)
        {
            var vacancyType = await _context.VacancyTypes.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vacancyType is null)
            {
                throw new NotFoundException(nameof(VacancyType), request.Id);
            }

            _context.VacancyTypes.Remove(vacancyType);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
