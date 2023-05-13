using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Vacancies.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Vacancies.Commands.UpdateVacancy
{
    public class UpdateVacancyHandler : IRequestHandler<UpdateVacancyRequest, VacancyModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public UpdateVacancyHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VacancyModel> Handle(UpdateVacancyRequest request, CancellationToken cancellationToken)
        {
            var vacancy = await _context.Vacancies
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vacancy is null)
            {
                throw new NotFoundException(nameof(Vacancy), request.Id);
            }

            vacancy.Title = request.Title;
            vacancy.Description = request.Description;
            vacancy.Salary = request.Salary;
            vacancy.SeniorityLevelId = request.SeniorityLevelId;
            vacancy.VacancyTypeId = request.VacancyTypeId;
            vacancy.VacancyStatusId = request.VacancyStatusId;
            vacancy.RecruiterId = request.RecruiterId;

            await _context.SaveChangesAsync(cancellationToken);

            var updatedVacancy = await _context.Vacancies
                .Include(vacancy => vacancy.SeniorityLevel)
                .Include(vacancy => vacancy.VacancyType)
                .Include(vacancy => vacancy.VacancyStatus)
                .Include(vacancy => vacancy.Recruiter)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            return _mapper.Map<VacancyModel>(updatedVacancy);
        }
    }
}
