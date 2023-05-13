using BoardingTracker.Application.Skills.Models;
using MediatR;

namespace BoardingTracker.Application.Skills.Commands.UpdateSkill
{
    public class UpdateSkillRequest : IRequest<SkillModel>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
