using AutoMapper;
using BoardingTracker.Application.Vacancies.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Vacancies.Commands.CreateVacancy
{
    public class CreateVacancyHandler : IRequestHandler<CreateVacancyRequest, VacancyModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public CreateVacancyHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VacancyModel> Handle(CreateVacancyRequest request, CancellationToken cancellationToken)
        {
            var vacancy = _mapper.Map<Vacancy>(request);

            _context.Vacancies.Add(vacancy);
            await _context.SaveChangesAsync(cancellationToken);

            var createdVacancy = await _context.Vacancies
                .Include(vacancy => vacancy.SeniorityLevel)
                .Include(vacancy => vacancy.VacancyType)
                .Include(vacancy => vacancy.VacancyStatus)
                .Include(vacancy => vacancy.Recruiter)
                .FirstOrDefaultAsync(x => x.Id == vacancy.Id);

            return _mapper.Map<VacancyModel>(createdVacancy);
        }
    }
}
