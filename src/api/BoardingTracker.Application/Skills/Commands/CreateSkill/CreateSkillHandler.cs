using AutoMapper;
using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;

namespace BoardingTracker.Application.Skills.Commands.CreateSkill
{
    public class CreateSkillHandler : IRequestHandler<CreateSkillRequest, SkillModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public CreateSkillHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SkillModel> Handle(CreateSkillRequest request, CancellationToken cancellationToken)
        {
            var skill = _mapper.Map<Skill>(request);

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SkillModel>(skill);
        }
    }
}
