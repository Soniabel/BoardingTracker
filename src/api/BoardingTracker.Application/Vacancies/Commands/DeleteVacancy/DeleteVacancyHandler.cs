using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Vacancies.Commands.DeleteVacancy
{
    public class DeleteVacancyHandler : IRequestHandler<DeleteVacancyRequest, int>
    {
        private readonly DBBoardingTrackerContext _context;

        public DeleteVacancyHandler(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteVacancyRequest request, CancellationToken cancellationToken)
        {
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vacancy is null)
            {
                throw new NotFoundException(nameof(Vacancy), request.Id);
            }

            _context.Vacancies.Remove(vacancy);
            await _context.SaveChangesAsync(cancellationToken);

            return vacancy.Id;
        }
    }
}
