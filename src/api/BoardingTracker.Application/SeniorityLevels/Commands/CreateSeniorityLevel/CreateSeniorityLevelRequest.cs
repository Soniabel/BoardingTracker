using BoardingTracker.Application.SeniorityLevels.Models;
using MediatR;

namespace BoardingTracker.Application.SeniorityLevels.Commands.CreateSeniorityLevel
{
    public class CreateSeniorityLevelRequest : IRequest<SeniorityLevelModel>
    {
        public string Name { get; set; } = null!;
    }
}
