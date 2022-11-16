using BoardingTracker.Application.Skills.Models;
using MediatR;

namespace BoardingTracker.Application.Skills.Queries.GetSkillById
{
    public class GetSkillByIdRequest : IRequest<SkillModel>
    {
        public int Id { get; set; }
    }
}
