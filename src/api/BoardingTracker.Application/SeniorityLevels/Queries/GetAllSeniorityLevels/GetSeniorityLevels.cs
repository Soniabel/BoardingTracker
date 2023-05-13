using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.SeniorityLevels.Queries.GetAllSeniorityLevels
{
    public class GetSeniorityLevels : IRequest<SeniorityLevelsList>
    {
        public class GetSeniorityLevelsHandler : IRequestHandler<GetSeniorityLevels, SeniorityLevelsList>
        {
            private readonly DBBoardingTrackerContext _context;
            private readonly IMapper _mapper;

            public GetSeniorityLevelsHandler(DBBoardingTrackerContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SeniorityLevelsList> Handle(GetSeniorityLevels request, CancellationToken cancellationToken)
            {
                var seniorityLevels = await _context.SeniorityLevels.AsNoTracking()
                    .Select(seniorityLevel => _mapper.Map<SeniorityLevelModel>(seniorityLevel))
                    .ToListAsync(cancellationToken);

                if (seniorityLevels is null)
                {
                    throw new NotFoundException("SeniorityLevels is empty!");
                }

                return new SeniorityLevelsList { Items = seniorityLevels };
            }
        }
    }
}
