using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.VacancyTypes.Models;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.VacancyTypes.Queries.GetAllVacancyTypes
{
    public class GetVacancyTypes : IRequest<VacancyTypeList>
    {
        public class GetVacancyTypesHandler : IRequestHandler<GetVacancyTypes, VacancyTypeList>
        {
            private readonly DBBoardingTrackerContext _context;
            private readonly IMapper _mapper;

            public GetVacancyTypesHandler(DBBoardingTrackerContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<VacancyTypeList> Handle(GetVacancyTypes request, CancellationToken cancellationToken)
            {
                var vacancyTypes = await _context.VacancyTypes.AsNoTracking()
                    .Select(vacancyType => _mapper.Map<VacancyTypeModel>(vacancyType))
                    .ToListAsync(cancellationToken);

                if (vacancyTypes is null)
                {
                    throw new NotFoundException("VacancyTypes is empty!");
                }

                return new VacancyTypeList { Items = vacancyTypes };
            }
        }
    }
}
