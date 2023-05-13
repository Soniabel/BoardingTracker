using AutoMapper;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Skills.Models;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Skills.Commands.UpdateSkill
{
    public class UpdateSkillHandler : IRequestHandler<UpdateSkillRequest, SkillModel>
    {
        private readonly DBBoardingTrackerContext _context;
        private readonly IMapper _mapper;

        public UpdateSkillHandler(DBBoardingTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SkillModel> Handle(UpdateSkillRequest request, CancellationToken cancellationToken)
        {
            var skill = await _context.Skills
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (skill is null)
            {
                throw new NotFoundException(nameof(Skill), request.Id);
            }

            skill.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SkillModel>(skill);
        }
    }
}
