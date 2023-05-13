using MediatR;

namespace BoardingTracker.Application.SeniorityLevels.Commands.DeleteSeniorityLevel
{
    public class DeleteSeniorityLevelRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
