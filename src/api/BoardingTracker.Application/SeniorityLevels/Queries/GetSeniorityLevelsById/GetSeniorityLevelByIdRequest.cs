using BoardingTracker.Application.SeniorityLevels.Models;
using MediatR;

namespace BoardingTracker.Application.SeniorityLevels.Queries.GetSeniorityLevelsById
{
    public class GetSeniorityLevelByIdRequest : IRequest<SeniorityLevelModel>
    {
        public int Id { get; set; }
    }
}
