using MediatR;

namespace BoardingTracker.Application.Skills.Commands.DeleteSkill
{
    public class DeleteSkillRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
