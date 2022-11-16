using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Vacancies.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Vacancies.Queries.GetVacanciesById
{
    public class GetVacancyByIdHandler : IRequestHandler<GetVacancyByIdRequest, VacancyModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetVacancyByIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VacancyModel> Handle(GetVacancyByIdRequest request, CancellationToken cancellationToken)
        {
            var vacancy = await _context.Vacancies.AsNoTracking()
                .Include(vacancy => vacancy.SeniorityLevel)
                .Include(vacancy => vacancy.VacancyType)
                .Include(vacancy => vacancy.VacancyStatus)
                .Include(vacancy => vacancy.Recruiter)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (vacancy is null)
            {
                throw new NotFoundException(nameof(Vacancy), request.Id);
            }

            return _mapper.Map<VacancyModel>(vacancy);
        }
    }
}
