using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.SeniorityLevels.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.SeniorityLevels.Commands.UpdateSeniorityLevel
{
    public class UpdateSeniorityLevelHandler : IRequestHandler<UpdateSeniorityLevelRequest, SeniorityLevelModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public UpdateSeniorityLevelHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SeniorityLevelModel> Handle(UpdateSeniorityLevelRequest request, CancellationToken cancellationToken)
        {
            var seniorityLevel = await _context.SeniorityLevels
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (seniorityLevel is null)
            {
                throw new NotFoundException(nameof(SeniorityLevel), request.Id);
            }

            seniorityLevel.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SeniorityLevelModel>(seniorityLevel);
        }
    }
}
