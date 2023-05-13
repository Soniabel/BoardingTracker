using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.SeniorityLevels.Queries.GetSeniorityLevelsById
{
    public class GetSeniorityLevelByIdHandler : IRequestHandler<GetSeniorityLevelByIdRequest, SeniorityLevelModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetSeniorityLevelByIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SeniorityLevelModel> Handle(GetSeniorityLevelByIdRequest request, CancellationToken cancellationToken)
        {
            var seniorityLevel = await _context.SeniorityLevels.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (seniorityLevel is null)
            {
                throw new NotFoundException(nameof(SeniorityLevel), request.Id);
            }

            return _mapper.Map<SeniorityLevelModel>(seniorityLevel);
        }
    }
}
