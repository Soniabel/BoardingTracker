using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Skills.Queries.GetAllSkills
{
    public class GetSkills : IRequest<SkillList>
    {
        public class GetSkillsHandler : IRequestHandler<GetSkills, SkillList>
        {
            private readonly DBBoardingTrackerContext _context;
            private readonly IMapper _mapper;

            public GetSkillsHandler(DBBoardingTrackerContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SkillList> Handle(GetSkills request, CancellationToken cancellationToken)
            {
                var skills = await _context.Skills.AsNoTracking()
                    .Select(skill => _mapper.Map<SkillModel>(skill))
                    .ToListAsync(cancellationToken);

                if (skills is null)
                {
                    throw new NotFoundException("Skills is empty!");
                }

                return new SkillList { Items = skills };
            }
        }
    }
}
