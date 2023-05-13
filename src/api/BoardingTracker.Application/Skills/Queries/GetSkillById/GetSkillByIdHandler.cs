using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Skills.Queries.GetSkillById
{
    public class GetSkillByIdHandler : IRequestHandler<GetSkillByIdRequest, SkillModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public GetSkillByIdHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SkillModel> Handle(GetSkillByIdRequest request, CancellationToken cancellationToken)
        {
            var skill = await _context.Skills.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (skill is null)
            {
                throw new NotFoundException(nameof(Skill), request.Id);
            }

            return _mapper.Map<SkillModel>(skill);
        }
    }
}
