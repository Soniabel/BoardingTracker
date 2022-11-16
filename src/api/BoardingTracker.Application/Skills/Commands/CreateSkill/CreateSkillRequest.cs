using BoardingTracker.Application.Skills.Models;
using MediatR;

namespace BoardingTracker.Application.Skills.Commands.CreateSkill
{
    public class CreateSkillRequest : IRequest<SkillModel>
    {
        public string Name { get; set; } = null!;
    }
}
