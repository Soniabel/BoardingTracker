using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Vacancies.Models;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Vacancies.Queries.GetAllVacancies
{
    public class GetVacancies : IRequest<VacanciesList>
    {
        public class GetVacanciesHandler : IRequestHandler<GetVacancies, VacanciesList>
        {
            private readonly DBBoardingTrackerContext _context;
            private readonly IMapper _mapper;

            public GetVacanciesHandler(DBBoardingTrackerContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<VacanciesList> Handle(GetVacancies request, CancellationToken cancellationToken)
            {
                var vacancies = await _context.Vacancies.AsNoTracking()
                    .Include(vacancy => vacancy.SeniorityLevel)
                    .Include(vacancy => vacancy.VacancyType)
                    .Include(vacancy => vacancy.VacancyStatus)
                    .Include(vacancy => vacancy.Recruiter)
                    .Select(vacancy => _mapper.Map<VacancyModel>(vacancy))
                    .ToListAsync(cancellationToken);

                if (vacancies is null)
                {
                    throw new NotFoundException("Vacancies is empty!");
                }

                return new VacanciesList { Items = vacancies };
            }
        }
    }
}
