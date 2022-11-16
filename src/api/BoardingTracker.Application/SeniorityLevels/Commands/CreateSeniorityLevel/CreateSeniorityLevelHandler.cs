using AutoMapper;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;

namespace BoardingTracker.Application.SeniorityLevels.Commands.CreateSeniorityLevel
{
    public class CreateSeniorityLevelHandler : IRequestHandler<CreateSeniorityLevelRequest, SeniorityLevelModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public CreateSeniorityLevelHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SeniorityLevelModel> Handle(CreateSeniorityLevelRequest request, CancellationToken cancellationToken)
        {
            var seniorityLevel = _mapper.Map<SeniorityLevel>(request);

            _context.SeniorityLevels.Add(seniorityLevel);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SeniorityLevelModel>(seniorityLevel);
        }
    }
}
