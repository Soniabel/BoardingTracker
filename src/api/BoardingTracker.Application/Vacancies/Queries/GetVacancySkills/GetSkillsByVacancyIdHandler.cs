using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Vacancies.Queries.GetVacancySkills
{
    public class GetSkillsByVacancyIdHandler : IRequestHandler<GetSkillsByVacancyIdRequest, SkillList>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetSkillsByVacancyIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SkillList> Handle(GetSkillsByVacancyIdRequest request, CancellationToken cancellationToken)
        {
            var vacancy = await _context.Vacancies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vacancy is null)
            {
                throw new NotFoundException(nameof(Vacancy), request.Id);
            }

            var skills = await _context.VacancySkills.Where(vacancySkills => vacancySkills.VacancyId == request.Id)
                .Join(_context.Skills,
                vacancySkills => vacancySkills.SkillId,
                skill => skill.Id,
                (vacancySkills, skill) => _mapper.Map<SkillModel>(skill)).ToListAsync();

            if (skills is null)
            {
                throw new NotFoundException("Skills is empty!");
            }

            return new SkillList { Items = skills };
        }
    }
}
