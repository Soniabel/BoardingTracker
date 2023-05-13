using BoardingTracker.Application.SeniorityLevels.Models;
using MediatR;

namespace BoardingTracker.Application.SeniorityLevels.Commands.UpdateSeniorityLevel
{
    public class UpdateSeniorityLevelRequest : IRequest<SeniorityLevelModel>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
