using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.VacancyStatuses.Models;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.VacancyStatuses.Queries.GetAllVacancyStatuses
{
    public class GetVacancyStatuses : IRequest<VacancyStatusList>
    {
        public class GetVacancyStatusesHandler : IRequestHandler<GetVacancyStatuses, VacancyStatusList>
        {
            private readonly DBBoardingTrackerContext _context;
            private readonly IMapper _mapper;

            public GetVacancyStatusesHandler(DBBoardingTrackerContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<VacancyStatusList> Handle(GetVacancyStatuses request, CancellationToken cancellationToken)
            {
                var vacancyStatuses = await _context.VacancyStatuses.AsNoTracking()
                    .Select(vacancyStatus => _mapper.Map<VacancyStatusModel>(vacancyStatus))
                    .ToListAsync(cancellationToken);

                if (vacancyStatuses is null)
                {
                    throw new NotFoundException("VacancyStatuses is empty!");
                }

                return new VacancyStatusList { Items = vacancyStatuses };
            }
        }
    }
}
