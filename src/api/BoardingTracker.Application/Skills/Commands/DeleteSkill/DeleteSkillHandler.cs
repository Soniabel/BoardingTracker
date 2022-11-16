using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Domain.Entities;
using BoardingTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoardingTracker.Application.Skills.Commands.DeleteSkill
{
    public class DeleteSkillHandler : IRequestHandler<DeleteSkillRequest, int>
    {
        private readonly DBBoardingTrackerContext _context;

        public DeleteSkillHandler(DBBoardingTrackerContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteSkillRequest request, CancellationToken cancellationToken)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (skill is null)
            {
                throw new NotFoundException(nameof(Skill), request.Id);
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync(cancellationToken);

            return skill.Id;
        }
    }
}
