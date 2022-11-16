using AutoMapper;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;

namespace BoardingTracker.Application.VacancyStatuses.Commands.CreateVacancyStatus
{
    public class CreateVacancyStatusHandler : IRequestHandler<CreateVacancyStatusRequest, VacancyStatusModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public CreateVacancyStatusHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VacancyStatusModel> Handle(CreateVacancyStatusRequest request, CancellationToken cancellationToken)
        {
            var vacancyStatus = _mapper.Map<VacancyStatus>(request);

            _context.VacancyStatuses.Add(vacancyStatus);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<VacancyStatusModel>(vacancyStatus);
        }
    }
}
